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
    public class MediaTypeController : ControllerBase
    {
        private readonly IRepository<MediaType> _repository;
        public MediaTypeController(IRepository<MediaType> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaType>>> GetMediaTypes()
        {
            return Ok(await _repository.Read());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<MediaType>> PostMediaType(MediaType MediaType)
        {
            await _repository.Create(MediaType);
            return Ok(MediaType.MediaTypeId);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<bool>> PutMediaType(MediaType MediaType)
        {
            return Ok(await _repository.Update(MediaType));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteMediaType(int MediaTypeId)
        {
            return Ok(await _repository.Delete(new MediaType { MediaTypeId = MediaTypeId }));
        }
    }
}
