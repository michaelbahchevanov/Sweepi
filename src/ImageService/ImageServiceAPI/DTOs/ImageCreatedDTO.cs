using Sweepi.ImageServiceAPI.Models;

namespace Sweepi.ImageServiceAPI.DTOs
{
  public class ImageCreatedDto : IEntity
  {
    public string Id { get; set; }
    public string ImageUrl { get; set; }
  }
}