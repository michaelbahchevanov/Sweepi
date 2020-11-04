using System;
using System.ComponentModel.DataAnnotations;
using Sweepi.ProductServiceAPI.Data;

namespace Sweepi.ProductServiceAPI.Models
{
  public class Product : IEntity
  {
    [Key]
    public string Id { get; set; }
    [Required(ErrorMessage="Name is required")]
    [MaxLength(150)]
    public string Name { get; set; }
    public bool Favourite { get; set; } = false;
    [Required(ErrorMessage="Item should belong to a category")]
    [MaxLength(100)]
    public string Category { get; set; }
    public DateTime? Expiration { get; set; }
  }
}