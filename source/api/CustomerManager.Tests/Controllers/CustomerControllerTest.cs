using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CustomerManager.Core.Entities;
using CustomerManager.Core.Services;
using CustomerManager.Tests.Services;
using CustomerManager.Api.Controllers;
using CustomerManager.Core.Enumeration.Customer;

namespace CustomerManager.Tests.Controllers
{
    public class CustomerControllerTest
    {
        #region Private Read-Only Fields

        private readonly ICustomerService _service;
        private readonly CustomerController _controller;

        #endregion

        #region Constructors

        public CustomerControllerTest()
        {
            _service = new CustomerServiceFake();
            _controller = new CustomerController(_service);
        }

        #endregion

        #region Unit Tests

        [Fact]
        public async Task Get_WhenCalled_WithValidId_ReturnsOkObjectResult()
        {
            var output = await _controller.Get("5c7432b01d39ea2b383e6ac3");
            Assert.IsType<OkObjectResult>(output);
        }

        [Fact]
        public async Task Get_WhenCalled_WithEmptyId_ReturnsNotFoundResult()
        {
            var output = await _controller.Get("");
            Assert.IsType<NotFoundResult>(output);
        }

        [Fact]
        public async Task Get_WhenCalled_WithNullId_ReturnsNotFoundResult()
        {
            var output = await _controller.Get(null);
            Assert.IsType<NotFoundResult>(output);
        }

        [Fact]
        public async Task Get_WhenCalled_WithInvalidId_ReturnsNotFoundResult()
        {
            var output = await _controller.Get("xxxxx");
            Assert.IsType<NotFoundResult>(output);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsAllItems()
        {
            var output = await _controller.Get();

            Assert.IsType<OkObjectResult>(output);
            var collection = Assert.IsAssignableFrom<IEnumerable<Customer>>((output as OkObjectResult).Value);
            Assert.Equal(2, collection.Count());
        }

        [Fact]
        public async Task Post_WhenCalled_WithNullBody_ReturnsBadRequestResult()
        {
            var output = await _controller.Post(null);

            Assert.IsType<BadRequestResult>(output);
        }

        [Fact]
        public async Task Post_WhenCalled_WithEmptyFields_ReturnsBadRequestResult()
        {
            var customer = new Customer();
            var output = await _controller.Post(customer);

            Assert.IsType<BadRequestResult>(output);
        }

        [Fact]
        public async Task Post_WhenCalled_ReturnsOkObjectResult()
        {
            var customer = new Customer
            {
                Name = "Pessoa X",
                Birthday = new DateTime(1986, 03, 28),
                DocumentId = "43.361.398-1",
                SocialSecurityId = "518.632.660-70",
                Phones = new CustomerPhone[] { new CustomerPhone("(+5511) 95555-5555", PhoneType.CellPhone) },
                Addresses = new CustomerAddress[] { new CustomerAddress("Avenida dos Jequitibas", AddressType.Residential) },
                Facebook = "https://www.facebook.com/pessoa-x",
                LinkedIn = "https://www.linkedin.com/in/pessoa-x",
                Twitter = "https://www.twitter.com/pessoa-x",
                Instagram = "https://www.instagram.com/pessoa-x"
            };

            var output = await _controller.Post(customer);

            Assert.IsType<OkObjectResult>(output);
            var entity = Assert.IsType<Customer>((output as ObjectResult).Value);

            Assert.NotNull(entity.Id);
            Assert.NotEqual(DateTime.MinValue, entity.DateCreated);

            var result = await _controller.Get();
            var collection = Assert.IsAssignableFrom<IEnumerable<Customer>>((result as OkObjectResult).Value);

            Assert.Contains(collection, x => x.Id.Equals(customer.Id));
        }

        [Fact]
        public async Task Put_WhenCalled_WithEmptyId_ReturnsNotFoundResult()
        {
            var customer = new Customer();
            var output = await _controller.Put("", customer);

            Assert.IsType<NotFoundResult>(output);
        }

        [Fact]
        public async Task Put_WhenCalled_WithNullId_ReturnsNotFoundResult()
        {
            var customer = new Customer();
            var output = await _controller.Put(null, customer);

            Assert.IsType<NotFoundResult>(output);
        }

        [Fact]
        public async Task Put_WhenCalled_WithNotFoundId_ReturnsNotFoundResult()
        {
            var customer = new Customer {
                Id = Guid.NewGuid().ToString().Replace("-", "")
            };

            var output = await _controller.Put(customer.Id, customer);

            Assert.IsType<NotFoundResult>(output);
        }

        [Fact]
        public async Task Put_WhenCalled_WithValidIdAndEmptyFields_ReturnsBadRequestResult()
        {
            var customer = new Customer
            {
                Id = "6c8972b01d39ea2b383e6ab5"
            };

            var output = await _controller.Put(customer.Id, customer);

            Assert.IsType<BadRequestResult>(output);
        }

        [Fact]
        public async Task Put_WhenCalled_ReturnsOkObjectResult()
        {
            var customer = new Customer()
            {
                Id = "6c8972b01d39ea2b383e6ab5",
                Name = "Pessoa X",
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
                DateUpdated = DateTime.Now.Date
            };

            var output = await _controller.Put(customer.Id, customer);

            Assert.IsType<OkObjectResult>(output);
            var result = await _controller.Get(customer.Id);
            var entity = Assert.IsType<Customer>((result as OkObjectResult).Value);

            Assert.NotNull(entity);
            Assert.Equal(entity.Id, customer.Id);
            Assert.Equal(entity.Name, customer.Name);
            Assert.Equal(entity.DateUpdated?.Date, customer.DateUpdated?.Date);
        }

        [Fact]
        public async Task Delete_WhenCalled_WithEmptyId_ReturnNotFoundResult()
        {
            var output = await _controller.Delete("");

            Assert.IsType<NotFoundResult>(output);
        }

        [Fact]
        public async Task Delete_WhenCalled_WithNullId_ReturnNotFoundResult()
        {
            var output = await _controller.Delete(null);

            Assert.IsType<NotFoundResult>(output);
        }

        [Fact]
        public async Task Delete_WhenCalled_WithInvalidId_ReturnNotFoundResult()
        {
            var output = await _controller.Delete("xxx");

            Assert.IsType<NotFoundResult>(output);
        }

        [Fact]
        public async Task Delete_WhenCalled_ReturnOkResult()
        {
            var id = "6c8972b01d39ea2b383e6ab5";
            var output = await _controller.Delete(id);

            Assert.IsType<OkResult>(output);

            var result = await _controller.Get();
            var collection = Assert.IsAssignableFrom<IEnumerable<Customer>>((result as OkObjectResult).Value);

            Assert.DoesNotContain(collection, x => x.Id.Equals(id));
        }

        #endregion
    }
}
