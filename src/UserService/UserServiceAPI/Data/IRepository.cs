using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sweepi.UserServiceAPI.Data
{
    public interface IRepository<TEntity> 
        where TEntity : class, IEntity
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(string id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(string id);
    }
}