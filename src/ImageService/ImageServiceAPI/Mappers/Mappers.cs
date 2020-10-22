using Sweepi.ImageServiceAPI.DTOs;
using Sweepi.ImageServiceAPI.Models;

namespace Sweepi.ImageServiceAPI.Mappers
{
  public static class Mappers
  {
    public static ImageCreatedDTO MapToDTO(this Image source)
      => new ImageCreatedDTO()
        {
          Id = source.Id
        };
  }
}