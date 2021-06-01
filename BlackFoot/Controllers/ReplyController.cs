using System.Threading.Tasks;
using BlackFoot;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ReplyController : ControllerBase
{
  private readonly SqliteDbContext context;

  public ReplyController(SqliteDbContext context)
  {
    this.context = context;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetReply(long id)
  {
    var reply = await context.Replies.FindAsync(id);
    return (reply != null) ? Ok(reply) : NotFound();
  }

  [HttpGet]
  public async Task<IActionResult> GetReplies()
  {
    var replies = await context.Replies.ToListAsync();
    return (replies.Count > 0) ? Ok(replies) : NotFound();
  }
}