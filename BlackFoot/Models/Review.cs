using System.ComponentModel.DataAnnotations;

namespace BlackFoot.Models
{
  public class Review
  {
    [Key]
    public long Id { get; set; }
    public ulong Rating { get; set; }
    public string Content { get; set; }

  }
}