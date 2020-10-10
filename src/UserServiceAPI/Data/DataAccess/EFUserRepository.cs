using Sweepi.UserServiceAPI.Models;

namespace Sweepi.UserServiceAPI.Data
{
  public class EFUserRepository : EFRepository<UserReadDTO, UserCreateDTO, User, UserDbContext>
  {
    public EFUserRepository(UserDbContext context) : base(context)
    {
        
    }
  }
}