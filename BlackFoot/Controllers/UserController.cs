using System.Threading.Tasks;
using BlackFoot;
using BlackFoot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly SqliteDbContext context;

  public UserController(SqliteDbContext context)
  {
    this.context = context;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUser(long id)
  {
    var user = await context.Users.FindAsync(id);
    return (user != null) ? Ok(user) : NotFound();
  }

  [HttpPost]
  public async Task<IActionResult> Register(User user)
  {
    context.Users.Add(user);
    await context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetUser), new { Id = user.Id }, user);
  }
}