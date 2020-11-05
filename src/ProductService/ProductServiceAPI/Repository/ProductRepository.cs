using Sweepi.ProductServiceAPI.Data;
using Sweepi.ProductServiceAPI.Models;

namespace Sweepi.ProductServiceAPI.Repository
{
  public class ProductRepository : ProductRepository<Product, ProductDbContext>
  {
    public ProductRepository(ProductDbContext context) : base(context)
    {
        
    }
  }
}