using System.ComponentModel.DataAnnotations;

namespace BlackFoot.Models
{
  public class User
  {
    [Key]
    public long Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public long Point { get; set; }
  }
}