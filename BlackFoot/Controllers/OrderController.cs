using System.Threading.Tasks;
using BlackFoot;
using BlackFoot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
  private readonly SqliteDbContext context;

  public OrderController(SqliteDbContext context)
  {
    this.context = context;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetOrder(long id)
  {
    var order = await context.Orders.FindAsync(id);
    return (order != null) ? Ok(order) : NotFound();
  }

  [HttpGet]
  public async Task<IActionResult> GetOrders()
  {
    var orders = await context.Orders.ToListAsync();
    return (orders.Count > 0) ? Ok(orders) : NotFound();
  }

  [HttpPost]
  public async Task<IActionResult> PostOrder(Order order)
  {
    context.Orders.Add(order);
    await context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetOrder), new { Id = order.Id }, order);
  }
}