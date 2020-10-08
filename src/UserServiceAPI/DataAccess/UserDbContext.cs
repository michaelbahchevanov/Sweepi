using Microsoft.EntityFrameworkCore;
using Sweepi.UserServiceAPI.Models;

namespace Sweepi.UserServiceAPI.DataAccess
{
  public class UserDbContext : DbContext
  {
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>().HasKey(u => u.UserId);
      builder.Entity<User>().ToTable("User");
      base.OnModelCreating(builder);
    }
  }
}