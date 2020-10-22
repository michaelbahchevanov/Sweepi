using Sweepi.ImageServiceAPI.Models;

namespace Sweepi.ImageServiceAPI.Repository
{
  public class ImageRepository : BaseRepository<Image>
  {
    public ImageRepository(IImageDatabaseSettings settings) : base(settings)
    {
        
    }
  }
}