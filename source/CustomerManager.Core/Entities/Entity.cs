using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerManager.Core.Entities
{
    public interface IEntity
    {        
        #region IEntity Members

        string Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateUpdated { get; set; }

        #endregion
    }

    public abstract class Entity: IEntity
    {
        #region Public Properties

        [BsonId]
        [BsonElement(Order = 0)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("dateCreated", Order = 98)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local, Representation = BsonType.DateTime)]
        public DateTime DateCreated { get; set; }

        [BsonElement("dateUpdated", Order = 99)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local, Representation = BsonType.DateTime)]
        public DateTime? DateUpdated { get; set; }

        #endregion
    }
}
