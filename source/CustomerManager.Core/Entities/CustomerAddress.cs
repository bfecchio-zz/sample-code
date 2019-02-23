using MongoDB.Bson.Serialization.Attributes;
using CustomerManager.Core.Enumeration.Customer;

namespace CustomerManager.Core.Entities
{
    public class CustomerAddress
    {
        #region Public Properties

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("type")]
        public AddressType Type { get; set; }

        #endregion

        #region Constructors

        public CustomerAddress()
            : this(address: null, type: AddressType.Undefined)
        { }

        public CustomerAddress(string address, AddressType type)
        {
            this.Address = address;
            this.Type = type;
        }

        #endregion
    }
}
