using System.Threading.Tasks;
using BlackFoot;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
  private readonly SqliteDbContext context;

  public RoleController(SqliteDbContext context)
  {
    this.context = context;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetRole(long id)
  {
    var role = await context.Roles.FindAsync(id);
    return (role != null) ? Ok(role) : NotFound();
  }

  [HttpGet]
  public async Task<IActionResult> GetRoles()
  {
    var roles = await context.Roles.ToListAsync();
    return (roles.Count > 0) ? Ok(roles) : NotFound();
  }
}