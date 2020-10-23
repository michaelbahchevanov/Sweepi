using Sweepi.ImageServiceAPI.Models;

namespace Sweepi.ImageServiceAPI.DTOs
{
  public class ImageCreatedDTO : IEntity
  {
    public string Id { get; set; }
    public string ImageUrl { get; set; }
  }
}