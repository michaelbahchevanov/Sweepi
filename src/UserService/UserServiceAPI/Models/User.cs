using System.ComponentModel.DataAnnotations;
using Sweepi.UserServiceAPI.Data;

namespace Sweepi.UserServiceAPI.Models
{
    public class User : IEntity
    {
      [Key]
      public string Id { get; set; }
      
      [MaxLength(100)]
      public string Name { get; set; }
      
      [MaxLength(255)]
      public string Email { get; set; }

      [MaxLength(256)]
      public string Password { get; set; }
    }
}