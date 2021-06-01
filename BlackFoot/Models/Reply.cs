using System.ComponentModel.DataAnnotations;

namespace BlackFoot.Models
{
  public class Reply
  {
    [Key]
    public long Id { get; set; }
    public string Content { get; set; }
  }
}