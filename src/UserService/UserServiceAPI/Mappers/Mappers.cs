using Sweepi.UserServiceAPI.DTOs;
using Sweepi.UserServiceAPI.Models;

namespace Sweepi.UserServiceAPI.Mappers
{
    public static class Mappers
    {
      public static UserDTO MapToDTO(this User source) 
        => new UserDTO() 
          {
            Id = source.Id,
            Name = source.Name
          };
      
      public static CreatedUserDTO MapToCreatedDTO(this User source)
        => new CreatedUserDTO()
          {
            Id = source.Id
          };
    }
}