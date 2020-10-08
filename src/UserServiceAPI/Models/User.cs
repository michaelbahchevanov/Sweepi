using System.ComponentModel.DataAnnotations;

namespace Sweepi.UserServiceAPI.Models
{
    public class User
    {
      [Key]
      public string UserId { get; set; }
      [Required]
      [MaxLength(100)]
      public string Name { get; set; }
      [Required]
      [MaxLength(255)]
      public string Email { get; set; }
      [Required]
      [MaxLength(255)]
      public string Password { get; set; }
    }
}