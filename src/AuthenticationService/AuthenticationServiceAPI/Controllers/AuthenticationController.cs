using Microsoft.AspNetCore.Mvc;
using Sweepi.AuthenticationServiceAPI.Dtos;
using Sweepi.AuthenticationServiceAPI.Models;
using Sweepi.AuthenticationServiceAPI.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Sweepi.UserServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthenticationController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage))
                });
            }

            var response = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!response.Success)
            {
                return BadRequest(new AuthFailResponse
                {
                    Errors = response.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                UserId = response.UserId,
                Token = response.Token,
                RefreshToken = response.RefreshToken
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var response = await _identityService.LoginAsync(request.Email, request.Password);

            if (!response.Success)
            {
                return BadRequest(new AuthFailResponse
                {
                    Errors = response.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                UserId = response.UserId,
                Token = response.Token,
                RefreshToken = response.RefreshToken
            });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        {
            var response = await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken);

            if (!response.Success)
            {
                return BadRequest(new AuthFailResponse
                {
                    Errors = response.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = response.Token,
                RefreshToken = response.RefreshToken
            });
        }
    }
}
