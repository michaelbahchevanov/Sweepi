using Sweepi.UserServiceAPI.Models;
using Sweepi.UserServiceAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Sweepi.UserServiceAPI.Repository;

namespace Sweepi.UserServiceAPI.Contollers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User, UserRepository>
    {
      public UsersController(UserRepository repository) : base(repository)
      {
          
      }
    }
}