using System.ComponentModel.DataAnnotations;

namespace Sweepi.UserServiceAPI.Models
{
    public class User
    {
      [Key]
      public string UserId { get; set; }
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