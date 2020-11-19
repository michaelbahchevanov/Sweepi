
namespace Sweepi.UserServiceAPI.Services
{
  public interface IAuthenticationManager
  {
    string AuthenticateRequest(string email, string password);
  }
}