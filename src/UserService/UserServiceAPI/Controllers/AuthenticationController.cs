using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sweepi.UserServiceAPI.Models;
using Sweepi.UserServiceAPI.Services;

namespace Sweepi.UserServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager authenticationManager;

        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public  IActionResult Authenticate([FromBody] User user)
        {
            var token = authenticationManager.AuthenticateRequest(user.Email, user.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
