using System.Linq;
using System.Threading.Tasks;
using BlackFoot;
using BlackFoot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
  private readonly SqliteDbContext context;

  public ReviewController(SqliteDbContext context)
  {
    this.context = context;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetReview(long id)
  {
    var review = await context.Reviews.FindAsync(id);
    return (review != null) ? Ok(review) : NotFound();
  }

  [HttpGet]
  public async Task<IActionResult> GetReviews()
  {
    var reviews = await context.Reviews.ToListAsync();
    return (reviews.Count > 0) ? Ok(reviews) : NotFound();
  }

  [HttpPost]
  public async Task<IActionResult> PostReview(Review review)
  {
    context.Reviews.Add(review);
    await context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetReview), new { Id = review.Id }, review);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> PutReview(long id, Review review)
  {
    if (id != review.Id)
      return BadRequest();
    
    context.Entry(review).State = EntityState.Modified;

    try
    {
      await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!ReviewExists(id))
        return NotFound();
      throw;
    }
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteReview(long id)
  {
    var review = await context.Reviews.FindAsync(id);
    if (review == null)
      return NotFound();
    
    context.Reviews.Remove(review);
    await context.SaveChangesAsync();
    return NoContent();
  }

  private bool ReviewExists(long id) => context.Reviews.Any(e => e.Id == id);
}