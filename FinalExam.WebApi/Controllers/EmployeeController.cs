using System.Collections.Generic;
using System.Threading.Tasks;
using FinalExam.WebApi.Models;
using FinalExam.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(await _repository.Read());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee Employee)
        {
            await _repository.Create(Employee);
            return Ok(Employee.EmployeeId);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<bool>> PutEmployee(Employee Employee)
        {
            return Ok(await _repository.Update(Employee));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteEmployee(int EmployeeId)
        {
            return Ok(await _repository.Delete(new Employee { EmployeeId = EmployeeId }));
        }
    }
}
