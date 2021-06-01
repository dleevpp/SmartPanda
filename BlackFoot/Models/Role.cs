using System.ComponentModel.DataAnnotations;

namespace BlackFoot.Models
{
  public class Role
  {
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
  }
}