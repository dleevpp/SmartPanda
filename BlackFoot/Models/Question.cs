using System.ComponentModel.DataAnnotations;

namespace BlackFoot.Models
{
  public class Question
  {
    [Key]
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
  }
}