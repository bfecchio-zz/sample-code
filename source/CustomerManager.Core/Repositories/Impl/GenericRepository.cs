using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using CustomerManager.Core.Data;
using System.Collections.Generic;
using CustomerManager.Core.Entities;
using CustomerManager.Core.Extensions;
using CustomerManager.Core.Infrastructure.Attributes;

namespace CustomerManager.Core.Repositories.Impl
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity: class, IEntity
    {
        #region Protected Read-Only Fields

        private readonly IDbContext _dbContext;
        private readonly IMongoCollection<TEntity> _dbCollection;

        #endregion

        #region Constructors

        public GenericRepository(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            typeof(TEntity).TryGetAttribute((BsonCollectionAttribute bc) => bc.Name, out var collectionName);
            _dbCollection = _dbContext.GetDatabase().GetCollection<TEntity>(collectionName);            
        }

        #endregion

        #region IGenericRepository Members

        public virtual async Task Create(TEntity entity)
        {            
            await _dbCollection.InsertOneAsync(entity);
        }

        public virtual async Task<bool> Delete(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            var result = await _dbCollection.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public virtual async Task<TEntity> Get(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbCollection.Find(_ => true).ToListAsync();
        }

        public virtual async Task<bool> Update(TEntity entity)
        {            
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
            var result = await _dbCollection.ReplaceOneAsync(filter, entity);            

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        #endregion
    }
}
