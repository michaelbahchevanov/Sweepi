using Microsoft.EntityFrameworkCore;
using Sweepi.ProductServiceAPI.Models;

namespace Sweepi.ProductServiceAPI.Data
{
  public class ProductDbContext : DbContext
  {
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Product>().HasKey(p => p.Id);
      modelBuilder.Entity<Product>().ToTable("Product");
      base.OnModelCreating(modelBuilder);
    }
  }
}