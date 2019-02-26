using System;

namespace CustomerManager.Core.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public class BsonCollectionAttribute : Attribute
    {
        #region Public Properties

        public string Name { get;  }

        #endregion

        #region Constructors

        public BsonCollectionAttribute(string collectionName)
        {
            this.Name = collectionName ?? throw new ArgumentNullException(nameof(collectionName));
        }

        #endregion
    }
}
