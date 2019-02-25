using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerManager.Core.Services;
using CustomerManager.Tests.Services;
using CustomerManager.Api.Controllers;
using CustomerManager.Core.Entities;
using System.Collections.Generic;
using System.Linq;

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

        #endregion
    }
}
