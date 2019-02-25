using CustomerManager.Core.Entities;
using CustomerManager.Core.Validators;

namespace CustomerManager.Core.Services
{
    public interface ICustomerService : IGenericService<Customer, ICustomerValidator>
    {
        #region ICustomerService Members

        #endregion
    }
}
