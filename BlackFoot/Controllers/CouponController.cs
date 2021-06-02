using System.Threading.Tasks;
using BlackFoot;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CouponController : ControllerBase
{
  private readonly SqliteDbContext context;

  public CouponController(SqliteDbContext context)
  {
    this.context = context;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetCoupon(long id)
  {
    var coupon = await context.Coupons.FindAsync(id);
    return (coupon != null) ? Ok(coupon) : NotFound();
  }

  [HttpGet]
  public async Task<IActionResult> GetCoupons()
  {
    var coupons = await context.Coupons.ToListAsync();
    return (coupons.Count > 0) ? Ok(coupons) : NotFound();
  }
}