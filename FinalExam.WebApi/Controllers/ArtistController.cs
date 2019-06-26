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
    public class ArtistController : ControllerBase
    {
        private readonly IRepository<Artist> _repository;
        public ArtistController(IRepository<Artist> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return Ok(await _repository.Read());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist Artist)
        {
            await _repository.Create(Artist);
            return Ok(Artist.ArtistId);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<bool>> PutArtist(Artist Artist)
        {
            return Ok(await _repository.Update(Artist));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteArtist(int ArtistId)
        {
            return Ok(await _repository.Delete(new Artist { ArtistId = ArtistId }));
        }
    }
}
