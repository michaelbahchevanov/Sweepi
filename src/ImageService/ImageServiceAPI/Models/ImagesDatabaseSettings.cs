namespace Sweepi.ImageServiceAPI.Models
{
  public class ImagesDatabaseSettings : IImageDatabaseSettings
  {
    string ImagesCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }
}