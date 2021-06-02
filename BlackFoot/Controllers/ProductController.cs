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
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> logger;
  private readonly SqliteDbContext context;

  public ProductController(ILogger<ProductController> logger, SqliteDbContext context)
  {
    this.logger = logger;
    this.context = context;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetProduct(long id)
  {
    var product = await context.Products.FindAsync(id);
    return (product != null) ? Ok(product) : NotFound();
  }

  [AllowAnonymous]
  [HttpGet]
  [Route("all")]
  public async Task<IActionResult> GetProducts()
  {
    var products = await context.Products.ToListAsync();
    return (products.Count > 0) ? Ok(products) : NotFound();
  }

  [Authorize]
  [HttpPost]
  public async Task<IActionResult> PostProduct(SubmitRequest request)
  {
    var product = new Product()
    {
      Category = request.Category,
      Name = request.Name,
      Price = request.Price,
      Company = request.Company,
      Country = request.Country,
      Sales = 0,
      Image = request.Image,
    };
    context.Products.Add(product);
    await context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
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

public class SubmitRequest
{
  [JsonPropertyName("category")]
  public string Category { get; set; }
  
  [JsonPropertyName("name")]
  public string Name { get; set; }
  
  [JsonPropertyName("price")]
  public long Price { get; set; }
  
  [JsonPropertyName("company")]
  public string Company { get; set; }

  [JsonPropertyName("country")]
  public string Country { get; set; }

  [JsonPropertyName("image")]
  public string Image { get; set; }
}