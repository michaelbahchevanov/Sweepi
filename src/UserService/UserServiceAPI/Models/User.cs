using System.ComponentModel.DataAnnotations;
using Sweepi.UserServiceAPI.Data;

namespace Sweepi.UserServiceAPI.Models
{
    public class User : IEntity
    {
      [Key]
      public string Id { get; set; }
      
      [Required(ErrorMessage = "Name is required")]
      [MaxLength(100)]
      public string Name { get; set; }
      
      [Required(ErrorMessage = "Email address is required")]
      [MaxLength(255)]
      public string Email { get; set; }

      [Required]
      [MaxLength(255)]
      public string Password { get; set; }
    }
}