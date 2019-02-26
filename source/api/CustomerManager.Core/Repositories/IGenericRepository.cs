using System.Threading.Tasks;
using System.Collections.Generic;
using CustomerManager.Core.Entities;

namespace CustomerManager.Core.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        #region IGenericRepository Members

        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> GetAll();                
        Task Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(string id);

        #endregion
    }
}
