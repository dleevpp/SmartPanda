using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;

namespace BlackFoot.Infrastructure
{
  public interface IJwtAuthManager
  {
    IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary { get; }
    JwtAuthResult GenerateTokens(string username, Claim[] claims, DateTime now);
    JwtAuthResult Refresh(string refreshToken, string accessToken, DateTime now);
    void RemoveExpiredRefreshTokens(DateTime now);
    void RemoveRefreshTokenByUserName(string userName);
    (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
  }

  public class JwtAuthManager : IJwtAuthManager
  {
    public IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary => usersRefreshTokens.ToImmutableDictionary();
    private readonly ConcurrentDictionary<string, RefreshToken> usersRefreshTokens;  // can store in a database or a distributed cache
    private readonly JwtTokenConfig jwtTokenConfig;
    private readonly byte[] secret;

    public JwtAuthManager(JwtTokenConfig jwtTokenConfig)
    {
      this.jwtTokenConfig = jwtTokenConfig;
      usersRefreshTokens = new ConcurrentDictionary<string, RefreshToken>();
      secret = Encoding.ASCII.GetBytes(jwtTokenConfig.Secret);
    }

    // optional: clean up expired refresh tokens
    public void RemoveExpiredRefreshTokens(DateTime now)
    {
      var expiredTokens = usersRefreshTokens.Where(x => x.Value.ExpireAt < now).ToList();
      foreach (var expiredToken in expiredTokens)
      {
        usersRefreshTokens.TryRemove(expiredToken.Key, out _);
      }
    }

    // can be more specific to ip, user agent, device name, etc.
    public void RemoveRefreshTokenByUserName(string userName)
    {
      var refreshTokens = usersRefreshTokens.Where(x => x.Value.Username == userName).ToList();
      foreach (var refreshToken in refreshTokens)
      {
        usersRefreshTokens.TryRemove(refreshToken.Key, out _);
      }
    }

    public JwtAuthResult GenerateTokens(string username, Claim[] claims, DateTime now)
    {
      var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
      var jwtToken = new JwtSecurityToken(
          jwtTokenConfig.Issuer,
          shouldAddAudienceClaim ? jwtTokenConfig.Audience : string.Empty,
          claims,
          expires: now.AddMinutes(jwtTokenConfig.AccessTokenExpiration),
          signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256));
      var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

      var refreshToken = new RefreshToken
      {
        Username = username,
        TokenString = GenerateRefreshTokenString(),
        ExpireAt = now.AddMinutes(jwtTokenConfig.RefreshTokenExpiration)
      };
      usersRefreshTokens.AddOrUpdate(refreshToken.TokenString, refreshToken, (_, _) => refreshToken);

      return new JwtAuthResult
      {
        AccessToken = accessToken,
        RefreshToken = refreshToken
      };
    }

    public JwtAuthResult Refresh(string refreshToken, string accessToken, DateTime now)
    {
      var (principal, jwtToken) = DecodeJwtToken(accessToken);
      if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
      {
        throw new SecurityTokenException("Invalid token");
      }

      var userName = principal.Identity?.Name;
      if (!usersRefreshTokens.TryGetValue(refreshToken, out var existingRefreshToken))
      {
        throw new SecurityTokenException("Invalid token");
      }
      if (existingRefreshToken.Username != userName || existingRefreshToken.ExpireAt < now)
      {
        throw new SecurityTokenException("Invalid token");
      }

      return GenerateTokens(userName, principal.Claims.ToArray(), now); // need to recover the original claims
    }

    public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token)
    {
      if (string.IsNullOrWhiteSpace(token))
      {
        throw new SecurityTokenException("Invalid token");
      }
      var principal = new JwtSecurityTokenHandler()
          .ValidateToken(token,
              new TokenValidationParameters
              {
                ValidateIssuer = true,
                ValidIssuer = jwtTokenConfig.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secret),
                ValidAudience = jwtTokenConfig.Audience,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(1)
              },
              out var validatedToken);
      return (principal, validatedToken as JwtSecurityToken);
    }

    private static string GenerateRefreshTokenString()
    {
      var randomNumber = new byte[32];
      using var randomNumberGenerator = RandomNumberGenerator.Create();
      randomNumberGenerator.GetBytes(randomNumber);
      return Convert.ToBase64String(randomNumber);
    }
  }

  public class JwtAuthResult
  {
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }

    [JsonPropertyName("refreshToken")]
    public RefreshToken RefreshToken { get; set; }
  }

  public class RefreshToken
  {
    [JsonPropertyName("username")]
    public string Username { get; set; }    // can be used for usage tracking
                                            // can optionally include other metadata, such as user agent, ip address, device name, and so on

    [JsonPropertyName("tokenString")]
    public string TokenString { get; set; }

    [JsonPropertyName("expireAt")]
    public DateTime ExpireAt { get; set; }
  }
}