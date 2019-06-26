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
    public class InvoiceController : ControllerBase
    {
        private readonly IRepository<Invoice> _repository;
        public InvoiceController(IRepository<Invoice> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            return Ok(await _repository.Read());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice Invoice)
        {
            await _repository.Create(Invoice);
            return Ok(Invoice.InvoiceId);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<bool>> PutInvoice(Invoice Invoice)
        {
            return Ok(await _repository.Update(Invoice));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteInvoice(int InvoiceId)
        {
            return Ok(await _repository.Delete(new Invoice { InvoiceId = InvoiceId }));
        }
    }
}
