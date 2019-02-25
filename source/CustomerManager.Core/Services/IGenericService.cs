using System.Threading.Tasks;
using System.Collections.Generic;
using CustomerManager.Core.Entities;

namespace CustomerManager.Core.Services
{
    public interface IGenericService<TEntity>
        where TEntity : class, IEntity
    {
        #region IGenericService Members

        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(string id);

        #endregion
    }
}
