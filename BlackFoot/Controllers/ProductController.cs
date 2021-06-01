using System.Linq;
using System.Threading.Tasks;
using BlackFoot;
using BlackFoot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
  private readonly SqliteDbContext context;

  public ProductController(SqliteDbContext context)
  {
    this.context = context;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetProduct(long id)
  {
    var product = await context.Products.FindAsync(id);
    return (product != null) ? Ok(product) : NotFound();
  }

  [HttpGet]
  public async Task<IActionResult> GetProducts()
  {
    var products = await context.Products.ToListAsync();
    return (products.Count > 0) ? Ok(products) : NotFound();
  }

  [HttpPost]
  public async Task<IActionResult> PostProduct(Product product)
  {
    context.Products.Add(product);
    await context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetProduct), new { Id = product.Id }, product);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> PutProduct(long id, Product product)
  {
    if (id != product.Id)
      return BadRequest();
    
    context.Entry(product).State = EntityState.Modified;

    try
    {
      await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!ProductExists(id))
        return NotFound();
      throw;
    }
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteProduct(long id)
  {
    var product = await context.Products.FindAsync(id);
    if (product == null)
      return NotFound();
    
    context.Products.Remove(product);
    await context.SaveChangesAsync();
    return NoContent();
  }

  [HttpGet("sales")]
  public async Task<IActionResult> GetProductsSales(long id)
  {
    var products = await context.Products.ToListAsync();
    var sales = products.Select(x => new { x.Id, x.Sales }).ToList();
    return (sales.Count > 0) ? Ok(sales) : NotFound();
  }

  private bool ProductExists(long id) => context.Products.Any(e => e.Id == id);
}