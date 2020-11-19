using Sweepi.UserServiceAPI.Data;
using Sweepi.UserServiceAPI.Models;

namespace Sweepi.UserServiceAPI.Repository
{
  public class UserRepository : Repository<User, UserDbContext>
  {
    public UserRepository(UserDbContext context) : base(context)
    {
        
    }
  }
}