using System;
using Sweepi.ProductServiceAPI.Data;

namespace Sweepi.ProductServiceAPI.Dtos
{
  public class ProductReadDto : IEntity
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Favourite { get; set; }
    public string Category { get; set; }
    public DateTime? Expiration { get; set; }
  }
}