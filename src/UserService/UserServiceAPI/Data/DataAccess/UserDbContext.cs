using Microsoft.EntityFrameworkCore;
using Sweepi.UserServiceAPI.Models;

namespace Sweepi.UserServiceAPI.Data
{
  public class UserDbContext : DbContext
  {
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasKey(u => u.Id);
      modelBuilder.Entity<User>().ToTable("User");
      base.OnModelCreating(modelBuilder);
    }
  }
}