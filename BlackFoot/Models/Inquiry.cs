using System.ComponentModel.DataAnnotations;

namespace BlackFoot.Models
{
  public class Inquiry
  {
    [Key]
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
  }
}