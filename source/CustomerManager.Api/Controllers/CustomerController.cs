using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerManager.Core.Entities;
using CustomerManager.Core.Repositories;

namespace CustomerManager.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Private Read-Only Fields

        private readonly ICustomerRepository _customerRepository;

        #endregion

        #region Constructors

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _customerRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _customerRepository.Get(id);
            if (result != null) return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            await _customerRepository.Create(customer);
            return new OkObjectResult(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Customer customer)
        {
            var entity = await _customerRepository.Get(id);
            if (entity == null) return NotFound();

            customer.Id = entity.Id;
            customer.DateCreated = entity.DateCreated;

            await _customerRepository.Update(customer);

            return new OkObjectResult(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var entity = await _customerRepository.Get(id);
            if (entity == null) return NotFound();
            
            await _customerRepository.Delete(id);

            return Ok();
        }

        #endregion
    }
}