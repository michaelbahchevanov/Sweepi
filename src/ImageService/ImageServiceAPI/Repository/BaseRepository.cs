using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Linq;
using Sweepi.ImageServiceAPI.Models;

namespace Sweepi.ImageServiceAPI.Repository
{
  public class BaseRepository<TEntity> : IImageRepository<TEntity>
    where TEntity : class, IEntity
  {
    protected readonly IMongoCollection<TEntity> _entities;
    public BaseRepository(IImageDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

      _entities = database.GetCollection<TEntity>(settings.ImagesCollectionName);

    }
    public async Task<TEntity> Create(TEntity entity)
    {
      await _entities.InsertOneAsync(entity);
      return entity;
    }

    public async Task<TEntity> Delete(string id) =>
      await _entities.FindOneAndDeleteAsync(entity => entity.Id == id);

    public async Task<IEnumerable<TEntity>> Get()
    {
      var images = await _entities.Find(image => true).ToListAsync();
      return images;
    }

    public async Task<TEntity> Get(string id) => 
      await _entities.Find<TEntity>(entity => entity.Id == id).FirstOrDefaultAsync();
  }
}