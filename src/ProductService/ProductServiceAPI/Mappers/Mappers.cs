using Sweepi.ProductServiceAPI.Dtos;
using Sweepi.ProductServiceAPI.Models;

namespace Sweepi.ProductServiceAPI.Mappers
{
  public static class Mappers
  {
    public static ProductCreatedDto MapToCreatedDto(this Product source) 
      => new ProductCreatedDto()
      {
        Id = source.Id
      };

    public static ProductReadDto MapToReadDto(this Product source)
      => new ProductReadDto()
      {
        Id = source.Id,
        Name = source.Name,
        Favourite = source.Favourite,
        Category = source.Category,
        Expiration = source.Expiration
      };
  }
}