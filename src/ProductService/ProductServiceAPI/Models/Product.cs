using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sweepi.ProductServiceAPI.Data;

namespace Sweepi.ProductServiceAPI.Models
{
  public class Product : IEntity
  {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
    public string Id { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required(ErrorMessage="Name is required")]
    [MaxLength(150)]
    public string Name { get; set; }

    public bool Favourite { get; set; }
            
    [MaxLength(100)]
    public string Category { get; set; }

    public DateTime? Expiration { get; set; }
  }
}