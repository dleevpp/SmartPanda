using System.ComponentModel.DataAnnotations;

namespace BlackFoot.Models
{
  public class Coupon
  {
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Discount { get; set; }
  }
}