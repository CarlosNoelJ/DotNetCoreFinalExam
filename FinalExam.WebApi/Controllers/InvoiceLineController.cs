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
    public class InvoiceLineController : ControllerBase
    {
        private readonly IRepository<InvoiceLine> _repository;
        public InvoiceLineController(IRepository<InvoiceLine> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceLine>>> GetInvoiceLines()
        {
            return Ok(await _repository.Read());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<InvoiceLine>> PostInvoiceLine(InvoiceLine InvoiceLine)
        {
            await _repository.Create(InvoiceLine);
            return Ok(InvoiceLine.InvoiceLineId);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<bool>> PutInvoiceLine(InvoiceLine InvoiceLine)
        {
            return Ok(await _repository.Update(InvoiceLine));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteInvoiceLine(int InvoiceLineId)
        {
            return Ok(await _repository.Delete(new InvoiceLine { InvoiceLineId = InvoiceLineId }));
        }
    }
}
