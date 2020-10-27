using Sweepi.ImageServiceAPI.DTOs;
using Sweepi.ImageServiceAPI.Models;

namespace Sweepi.ImageServiceAPI.Mappers
{
  public static class Mappers
  {
    public static ImageCreatedDto MapToDTO(this Image source)
      => new ImageCreatedDto()
        {
          Id = source.Id,
          ImageUrl = source.ImageUrl
        };
  }
}