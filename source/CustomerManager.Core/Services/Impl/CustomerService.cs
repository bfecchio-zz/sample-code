using CustomerManager.Core.Entities;
using CustomerManager.Core.Repositories;

namespace CustomerManager.Core.Services.Impl
{
    public sealed class CustomerService : GenericService<Customer, ICustomerRepository>, ICustomerService
    {
        #region Construtors

        public CustomerService(ICustomerRepository repository)
            : base(repository)
        { }

        #endregion
    }
}
