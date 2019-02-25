using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CustomerManager.Core.Entities;
using CustomerManager.Core.Repositories;

namespace CustomerManager.Core.Services.Impl
{
    public abstract class GenericService<TEntity, TRepository> : IGenericService<TEntity>
        where TEntity: class, IEntity
        where TRepository : class, IGenericRepository<TEntity>
    {
        #region Private Read-Only Fields

        private readonly IGenericRepository<TEntity> _repository;

        #endregion

        #region Constructors

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #endregion

        #region ICustomerService Members        

        public virtual async Task Create(TEntity entity)
        {
            entity.DateCreated = DateTime.Now;
            await _repository.Create(entity);
        }

        public virtual async Task<bool> Delete(string id)
        {
            return await _repository.Delete(id);
        }

        public virtual async Task<TEntity> Get(string id)
        {
            return await _repository.Get(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            entity.DateUpdated = DateTime.Now;
            return await _repository.Update(entity);
        }

        #endregion
    }
}
