using MongoDB.Bson.Serialization.Attributes;
using CustomerManager.Core.Enumeration.Customer;

namespace CustomerManager.Core.Entities
{
    public class CustomerPhone
    {
        #region Public Properties

        [BsonElement("number")]
        public string Number { get; set; }

        [BsonElement("type")]
        public PhoneType Type { get; set; }

        #endregion

        #region Constructors

        public CustomerPhone()
            : this(number: null, type: PhoneType.Undefined)
        { }

        public CustomerPhone(string number, PhoneType type)
        {
            this.Number = number;
            this.Type = type;
        }

        #endregion
    }
}
