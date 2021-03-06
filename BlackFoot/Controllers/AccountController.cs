using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlackFoot.Infrastructure;
using BlackFoot.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BlackFoot.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly ILogger<AccountController> _logger;
    private readonly IUserService _userService;
    private readonly IJwtAuthManager jwtAuthManager;

    public AccountController(ILogger<AccountController> logger, IUserService userService, IJwtAuthManager jwtAuthManager)
    {
      _logger = logger;
      _userService = userService;
      this.jwtAuthManager = jwtAuthManager;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult Login([FromBody] LoginRequest request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      if (!_userService.IsValidUserCredentials(request.Username, request.Password))
      {
        return Unauthorized();
      }

      var role = _userService.GetUserRole(request.Username);
      var claims = new[]
      {
        new Claim(ClaimTypes.Name, request.Username),
        new Claim(ClaimTypes.Role, role)
      };

      var jwtResult = jwtAuthManager.GenerateTokens(request.Username, claims, DateTime.Now);
      _logger.LogInformation($"User [{request.Username}] logged in the system.");
      return Ok(new LoginResult
      {
        Username = request.Username,
        Role = role,
        AccessToken = jwtResult.AccessToken,
        RefreshToken = jwtResult.RefreshToken.TokenString
      });
    }

    [HttpGet("user")]
    [Authorize]
    public ActionResult GetCurrentUser()
    {
      return Ok(new LoginResult
      {
        Username = User.Identity?.Name,
        Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
        OriginalUsername = User.FindFirst("OriginalUserName")?.Value
      });
    }

    [HttpPost("logout")]
    [Authorize]
    public ActionResult Logout()
    {
      // optionally "revoke" JWT token on the server side --> add the current token to a block-list
      // https://github.com/auth0/node-jsonwebtoken/issues/375
      var userName = User.Identity?.Name;
      jwtAuthManager.RemoveRefreshTokenByUserName(userName);
      _logger.LogInformation($"User [{userName}] logged out the system.");
      return Ok();
    }

    [HttpPost("refresh-token")]
    [Authorize]
    public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
      try
      {
        var userName = User.Identity?.Name;
        _logger.LogInformation($"User [{userName}] is trying to refresh JWT token.");

        if (string.IsNullOrWhiteSpace(request.RefreshToken))
        {
          return Unauthorized();
        }

        var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
        var jwtResult = jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);
        _logger.LogInformation($"User [{userName}] has refreshed JWT token.");
        return Ok(new LoginResult
        {
          Username = userName,
          Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
          AccessToken = jwtResult.AccessToken,
          RefreshToken = jwtResult.RefreshToken.TokenString
        });
      }
      catch (SecurityTokenException e)
      {
        return Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
      }
    }
  }

  public class LoginRequest
  {
    [Required]
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [Required]
    [JsonPropertyName("password")]
    public string Password { get; set; }
  }

  public class LoginResult
  {
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("originalUserName")]
    public string OriginalUsername { get; set; }

    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }

    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; }
  }

  public class RefreshTokenRequest
  {
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; }
  }

  public class ImpersonationRequest
  {
    [JsonPropertyName("username")]
    public string UserName { get; set; }
  }
}