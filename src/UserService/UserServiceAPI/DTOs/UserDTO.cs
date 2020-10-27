using Sweepi.UserServiceAPI.Data;

namespace Sweepi.UserServiceAPI.DTOs
{
    public class UserDto : IEntity
    {
      public string Id { get; set; }
      public string Name { get; set; }
    }
}