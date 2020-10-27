using Sweepi.UserServiceAPI.DTOs;
using Sweepi.UserServiceAPI.Models;

namespace Sweepi.UserServiceAPI.Mappers
{
    public static class Mappers
    {
      public static UserDto MapToDTO(this User source) 
        => new UserDto() 
          {
            Id = source.Id,
            Name = source.Name
          };
      
      public static CreatedUserDto MapToCreatedDTO(this User source)
        => new CreatedUserDto()
          {
            Id = source.Id
          };
    }
}