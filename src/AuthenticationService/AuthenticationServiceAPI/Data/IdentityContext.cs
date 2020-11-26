using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sweepi.AuthenticationServiceAPI.Domain;

namespace Sweepi.AuthenticationServiceAPI.Data
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}