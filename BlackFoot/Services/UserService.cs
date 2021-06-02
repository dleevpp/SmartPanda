using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace BlackFoot.Services
{
  public interface IUserService
  {
    bool IsValidUserCredentials(string userName, string password);
    string GetUserRole(string userName);
  }

  public class UserService : IUserService
  {
    private readonly ILogger<UserService> logger;
    private readonly SqliteDbContext context;

    // inject your database here for user validation
    public UserService(ILogger<UserService> logger, SqliteDbContext context)
    {
      this.logger = logger;
      this.context = context;
    }

    public bool IsValidUserCredentials(string username, string password)
    {
      logger.LogInformation($"Validating user [{username}]");
      
      if (string.IsNullOrWhiteSpace(username)
          || string.IsNullOrWhiteSpace(password))
      {
        return false;
      }
      return context.Users
        .Where(user => user.Username == username && user.Password == password)
        .Count() != 0;
    }

    public string GetUserRole(string username)
    {
      try
      {
        var user = context.Users
          .Where(user => user.Username == username)
          .First();

        switch (user.Role.Name)
        {
        case "Admin":     return UserRoles.Admin;
        case "Seller":    return UserRoles.Seller;
        case "Customer":  return UserRoles.Customer;
        default:          return string.Empty;
        }
      }
      catch
      {
        return string.Empty;
      }
    }
  }

  public static class UserRoles
  {
    public const string Admin = nameof(Admin);
    public const string Seller = nameof(Seller);
    public const string Customer = nameof(Customer);
  }
}