using System;
using System.Threading.Tasks;
using BlackFoot;
using BlackFoot.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

  [AllowAnonymous]
  [HttpPost]
  public async Task<IActionResult> Register(User user)
  {
    context.Users.Add(user);
    await context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
  }
}