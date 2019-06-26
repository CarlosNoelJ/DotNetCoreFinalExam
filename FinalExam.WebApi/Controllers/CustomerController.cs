using System.Collections.Generic;
using System.Threading.Tasks;
using FinalExam.WebApi.Models;
using FinalExam.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalExam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _repository;
        public CustomerController(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return Ok(await _repository.Read());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer Customer)
        {
            await _repository.Create(Customer);
            return Ok(Customer.CustomerId);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<bool>> PutCustomer(Customer Customer)
        {
            return Ok(await _repository.Update(Customer));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCustomer(int CustomerId)
        {
            return Ok(await _repository.Delete(new Customer { CustomerId = CustomerId }));
        }
    }
}
