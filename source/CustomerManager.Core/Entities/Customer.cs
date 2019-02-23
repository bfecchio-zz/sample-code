using System;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using CustomerManager.Core.Infrastructure.Attributes;

namespace CustomerManager.Core.Entities
{
    [BsonCollection("customers")]
    public class Customer : Entity
    {
        #region Public Properties

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("birthday")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local, Representation = BsonType.DateTime)]
        public DateTime Birthday { get; set; }

        [BsonElement("phones")]
        public ICollection<CustomerPhone> Phones { get; set; }

        [BsonElement("addresses")]
        public ICollection<CustomerAddress> Addresses { get; set; }

        [BsonElement("facebook")]
        public string Facebook { get; set; }

        [BsonElement("linkedin")]
        public string LinkedIn { get; set; }

        [BsonElement("twitter")]
        public string Twitter { get; set; }

        [BsonElement("instagram")]
        public string Instagram { get; set; }

        [BsonElement("documentId")]
        public string DocumentId { get; set; }

        [BsonElement("socialSecurityId")]
        public string SocialSecurityId { get; set; }

        #endregion

        #region Constructors

        public Customer()
        {
            this.Phones = new List<CustomerPhone>();
            this.Addresses = new List<CustomerAddress>();
        }

        #endregion
    }
}
