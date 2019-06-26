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
    public class TrackController : Controller
    {
        private readonly IRepository<Track> _repository;
        public TrackController(IRepository<Track> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
        {
            return Ok(await _repository.Read());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Track>> PostTrack(Track Track)
        {
            await _repository.Create(Track);
            return Ok(Track.TrackId);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<bool>> PutTrack(Track Track)
        {
            return Ok(await _repository.Update(Track));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTrack(int TrackId)
        {
            return Ok(await _repository.Delete(new Track { TrackId = TrackId }));
        }
    }
}
