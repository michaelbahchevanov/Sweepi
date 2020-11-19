using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sweepi.UserServiceAPI.Data;
using Sweepi.UserServiceAPI.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Sweepi.UserServiceAPI.Services
{
  public class AuthenticationManager : IAuthenticationManager
  {
    private readonly string key;
    private readonly UserDbContext _context;
    
    public AuthenticationManager(IConfiguration configuration, UserDbContext context)
    {
            this.key = configuration.GetSection("Secret").Value;
            _context = context;
    }

    public string AuthenticateRequest(string email, string password)
    {
            var user = _context.Set<User>().FirstOrDefault(u => u.Email == email);

            if (user.Email != email)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
    }
  }
}