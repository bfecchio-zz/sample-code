using Xunit;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CustomerManager.Core.Entities;
using CustomerManager.Core.Services;
using CustomerManager.Tests.Services;
using CustomerManager.Api.Controllers;
using System;
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

        

        #endregion
    }
}
