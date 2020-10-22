namespace Sweepi.ImageServiceAPI.Models
{
  public class ImagesDatabaseSettings : IImageDatabaseSettings
  {
    public string ImagesCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }
}