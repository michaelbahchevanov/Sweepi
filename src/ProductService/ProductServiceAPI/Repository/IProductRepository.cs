using Sweepi.ProductServiceAPI.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sweepi.ProductServiceAPI.Repository
{
  public interface IProductRepository<TEntity>
    where TEntity : class, IEntity
  {
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(string id);
    Task<TEntity> Create(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity> Delete(string id);
  }
}