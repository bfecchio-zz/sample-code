using CustomerManager.Core.Entities;
using CustomerManager.Core.Validators;
using CustomerManager.Core.Repositories;

namespace CustomerManager.Core.Services.Impl
{
    public sealed class CustomerService : GenericService<Customer, ICustomerValidator, ICustomerRepository>, ICustomerService
    {
        #region Construtors

        public CustomerService(ICustomerValidator validator, ICustomerRepository repository)
            : base(validator, repository)
        { }

        #endregion
    }
}
