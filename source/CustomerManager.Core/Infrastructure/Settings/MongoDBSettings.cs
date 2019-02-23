using System;

namespace CustomerManager.Core.Infrastructure.Settings
{
    public class MongoDbSettings
    {
        #region Public Properties

        public string DatabaseName { get; private set; }
        public string ConnectionString { get; private set; }

        #endregion

        #region Constructors

        public MongoDbSettings()
            : this(connectionString: null, databaseName: null)
        { }

        public MongoDbSettings(string connectionString, string databaseName)
        {
            this.DatabaseName = databaseName;
            this.ConnectionString = connectionString;
        }

        #endregion
    }
}
