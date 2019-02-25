using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CustomerManager.Core.Entities;
using CustomerManager.Core.Services;
using CustomerManager.Core.Enumeration.Customer;

namespace CustomerManager.Tests.Services
{
    public class CustomerServiceFake : ICustomerService
    {
        #region Private Read-Only Fields

        private List<Customer> _customers;

        #endregion

        #region Constructors

        public CustomerServiceFake()
        {
            this._customers = new List<Customer> {
                new Customer(){
                    Id = "5c7432b01d39ea2b383e6ac3",
                    Name = "Pessoa A",
                    Birthday = DateTime.Now.AddYears(-33),
                    DocumentId = "32.365.778-4",
                    SocialSecurityId = "334.457.685-40",
                    Phones = new CustomerPhone[]{
                        new CustomerPhone("(+5511) 99999-9999", PhoneType.CellPhone),
                        new CustomerPhone("(+5511) 5555-5555", PhoneType.Residential),
                    },
                    Addresses = new CustomerAddress[]{
                        new CustomerAddress("Rua A", AddressType.Commercial),
                        new CustomerAddress("Rua B", AddressType.Residential),
                    },
                    Facebook = "https://fb.com/pessoa-a",
                    LinkedIn = "https://linkedin.com/in/pessoa-a",
                    Twitter = "https://twitter.com/pessoa-a",
                    Instagram = "https://instagram.com/pessoa-a",
                    DateCreated = DateTime.Now                    
                },
                new Customer(){
                    Id = "6c8972b01d39ea2b383e6ab5",
                    Name = "Pessoa B",
                    Birthday = DateTime.Now.AddYears(-15),
                    DocumentId = "25.233.978-3",
                    SocialSecurityId = "451.339.254-20",
                    Phones = new CustomerPhone[]{
                        new CustomerPhone("(+5511) 98888-8888", PhoneType.CellPhone),
                        new CustomerPhone("(+5511) 5555-5555", PhoneType.Residential),
                    },
                    Addresses = new CustomerAddress[]{
                        new CustomerAddress("Avenida C", AddressType.Commercial),
                        new CustomerAddress("Alameda D", AddressType.Residential),
                    },
                    Facebook = "https://fb.com/pessoa-b",
                    LinkedIn = "https://linkedin.com/in/pessoa-b",
                    Twitter = "https://twitter.com/pessoa-b",
                    Instagram = "https://instagram.com/pessoa-b",
                    DateCreated = DateTime.Now.AddDays(-5),
                    DateUpdated = DateTime.Now.AddHours(-8) 
                }
            };
        }

        #endregion

        #region ICustomerRepository Members
       
        public async Task Create(Customer entity)
        {
            await Task.Run(() => _customers.Add(entity));
        }

        public async Task<bool> Delete(string id)
        {
            return await Task.Run(() => {
                var exists = _customers.FirstOrDefault(x => x.Id.Equals(id));
                if (exists == null) return false;

                _customers = _customers.Where(x => !x.Id.Equals(id)).ToList();
                return true;
            });
        }

        public async Task<Customer> Get(string id)
        {
            return await Task.Run(() => _customers.FirstOrDefault(x => x.Id.Equals(id)));
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await Task.Run(() => _customers.ToArray());
        }

        public async Task<bool> Update(Customer entity)
        {
            return await Task.Run(() => {
                var exists = _customers.FirstOrDefault(x => x.Id.Equals(entity.Id));
                if (exists == null) return false;

                exists = entity;
                return true;
            });
        }

        #endregion
    }
}
