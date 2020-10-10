using Sweepi.UserServiceAPI.Data;
using Sweepi.UserServiceAPI.Models;
using AutoMapper;

namespace Sweepi.UserServiceAPI.Profiles
{
    public class UsersProfile : Profile
    {
      public UsersProfile()
      {
          // User -> ReadDTO
          CreateMap<User, UserReadDTO>();
          // CreateDTO -> User
          CreateMap<UserCreateDTO, User>();
          // User -> CreateDTO
          CreateMap<User, UserCreateDTO>();
      }
    }
}