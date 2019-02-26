namespace CustomerManager.Core.Infrastructure.Settings
{
    public class AppSettings
    {
        #region Public Properties

        public MongoDbSettings MongoDB { get; private set; }

        #endregion

        #region Constructors

        public AppSettings(MongoDbSettings mongoDbSettings)
        {
            this.MongoDB = (mongoDbSettings is null ? new MongoDbSettings() : mongoDbSettings);
        }

        #endregion
    }
}
