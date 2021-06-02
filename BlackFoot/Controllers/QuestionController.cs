using System.Threading.Tasks;
using BlackFoot;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
  private readonly SqliteDbContext context;

  public QuestionController(SqliteDbContext context)
  {
    this.context = context;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetQuestion(long id)
  {
    var question = await context.Questions.FindAsync(id);
    return (question != null) ? Ok(question) : NotFound();
  }

  [HttpGet]
  public async Task<IActionResult> GetQuestions()
  {
    var questions = await context.Questions.ToListAsync();
    return (questions.Count > 0) ? Ok(questions) : NotFound();
  }
}