using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sweepi.ImageServiceAPI.Repository
{
  public interface IImageRepository<TEntity>
    where TEntity: class
  {
    Task<IEnumerable<TEntity>> Get();
    Task<TEntity> Get(string id);
    Task<TEntity> Create(TEntity entity);
    Task<TEntity> Delete(string id);
  }
}