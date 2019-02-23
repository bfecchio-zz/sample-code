using Microsoft.Extensions.Configuration;
using CustomerManager.Core.Infrastructure.Settings;

namespace CustomerManager.Core.Helpers
{
    public interface IAppSettingsHelper
    {
        #region IAppSettingsHelper Members

        AppSettings Settings { get; }

        #endregion
    }

    public class AppSettingsHelper : IAppSettingsHelper
    {
        #region IAppSettingsHelper Members

        public AppSettings Settings { get; private set; }

        #endregion

        #region Constructors

        public AppSettingsHelper(IConfiguration configuration)
        {
            if (configuration is null)
                Settings = new AppSettings(null);

            MongoDbSettings sectionMongoDb;

            if (configuration.GetSection("MongoDB") is null)
                sectionMongoDb = null;
            else
            {
                var section = configuration.GetSection("MongoDB");
                sectionMongoDb = new MongoDbSettings(connectionString: section["ConnectionString"], databaseName: section["Database"]);
            }

            Settings = new AppSettings(sectionMongoDb);
        }

        #endregion
    }
}
