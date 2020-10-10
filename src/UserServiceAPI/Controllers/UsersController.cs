using Sweepi.UserServiceAPI.Models;
using Sweepi.UserServiceAPI.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Sweepi.UserServiceAPI.Contollers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<UserReadDTO, UserCreateDTO, User, EFUserRepository>
    {
      public UsersController(EFUserRepository repository, IMapper mapper) : base(repository, mapper)
      {
          
      }
    }
}