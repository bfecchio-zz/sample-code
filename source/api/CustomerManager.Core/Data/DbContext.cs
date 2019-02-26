using System;
using MongoDB.Driver;
using CustomerManager.Core.Helpers;
using CustomerManager.Core.Infrastructure.Settings;

namespace CustomerManager.Core.Data
{
    public interface IDbContext
    {
        #region IDbContext Members

        IMongoDatabase GetDatabase();           

        #endregion
    }

    public class DbContext : IDbContext
    {
        #region Private Read-Only Fields

        private readonly IMongoClient _dbClient;
        private readonly MongoDbSettings _settings;        

        #endregion

        #region Constructors

        public DbContext(IAppSettingsHelper helper)
        {
            if (helper == null)
                throw new ArgumentNullException(nameof(helper));

            _settings = helper.Settings.MongoDB;
            _dbClient = new MongoClient(connectionString: _settings.ConnectionString);
        }

        #endregion

        #region IDbContext Members

        public IMongoDatabase GetDatabase() => _dbClient.GetDatabase(_settings.DatabaseName);

        #endregion
    }
}
