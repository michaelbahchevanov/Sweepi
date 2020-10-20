using System.Threading.Tasks;
using System.Collections.Generic;
using Sweepi.UserServiceAPI.Data;

namespace Sweepi.UserServiceAPI.Repository
{
    public interface IUserRepository<TEntity> 
        where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(string id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(string id);
    }
}