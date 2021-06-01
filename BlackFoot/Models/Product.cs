using System.ComponentModel.DataAnnotations;

namespace BlackFoot.Models
{
  public class Product
  {
    [Key]
    public long Id { get; set; }
    public string Category { get; set; }
    public string Name { get; set; }
    public long Price { get; set; }
    public string Company { get; set; }
    public string Country { get; set; }
    public ulong Sales { get; set; }
    public string Image { get; set; }
  }
}