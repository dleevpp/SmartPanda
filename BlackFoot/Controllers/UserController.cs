using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlackFoot;
using BlackFoot.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly ILogger<UserController> logger;
  private readonly SqliteDbContext context;

  public UserController(ILogger<UserController> logger, SqliteDbContext context)
  {
    this.logger = logger;
    this.context = context;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUser(long id)
  {
    var user = await context.Users.FindAsync(id);
    return (user != null) ? Ok(user) : NotFound();
  }

  [HttpGet]
  public IActionResult GetUserByName([FromQuery(Name = "username")] string username)
  {
    var user = context.Users
      .Where(user => user.Username == username)
      .First();
    return (user != null) ? Ok(user) : NotFound();
  }

  [HttpGet]
  [Route("all")]
  public async Task<IActionResult> GetUsers()
  {
    var query = from u in context.Users
                join r in context.Roles on u.Role.Id equals r.Id
                select new User()
                {
                  Id = u.Id,
                  Username = u.Username,
                  Password = u.Password,
                  Address1 = u.Address1,
                  Address2 = u.Address2,
                  Role = r,
                };
    var user = await query.ToListAsync();
    return (user != null) ? Ok(user) : NotFound();
  }

  [AllowAnonymous]
  [HttpPost]
  public async Task<IActionResult> Register(RegisterRequest request)
  {
    var role = context.Roles
      .Where(role => role.Name == request.Role)
      .First();
    
    var user = new User()
    {
      Username = request.Username,
      Password = request.Password,
      Address1 = request.Address1,
      Address2 = request.Address2,
      Role = role,
    };
    context.Users.Add(user);
    await context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteUser(long id)
  {
    var user = await context.Users.FindAsync(id);
    if (user == null)
      return NotFound();
    context.Users.Remove(user);
    await context.SaveChangesAsync();
    return NoContent(); 
  }
}
public class RegisterRequest
{
  [JsonPropertyName("username")]
  public string Username { get; set; }
  
  [JsonPropertyName("password")]
  public string Password { get; set; }
  
  [JsonPropertyName("address1")]
  public string Address1 { get; set; }
  
  [JsonPropertyName("address2")]
  public string Address2 { get; set; }

  [JsonPropertyName("Role")]
  public string Role { get; set; }
}