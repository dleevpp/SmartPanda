using System;
using System.ComponentModel.DataAnnotations;

namespace BlackFoot.Models
{
  public class Order
  {
    [Key]
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public ulong Count { get; set; }
    public bool HasShipped { get; set; }
    public bool IsCancelled { get; set; }
  }
}