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
    public class PlaylistTrackController : Controller
    {
        private readonly IRepository<PlaylistTrack> _repository;
        public PlaylistTrackController(IRepository<PlaylistTrack> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistTrack>>> GetPlaylistTracks()
        {
            return Ok(await _repository.Read());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<PlaylistTrack>> PostPlaylistTrack(PlaylistTrack PlaylistTrack)
        {
            await _repository.Create(PlaylistTrack);
            return Ok(PlaylistTrack.PlaylistId);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<bool>> PutPlaylistTrack(PlaylistTrack PlaylistTrack)
        {
            return Ok(await _repository.Update(PlaylistTrack));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeletePlaylistTrack(int PlaylistTrackId)
        {
            return Ok(await _repository.Delete(new PlaylistTrack { PlaylistId = PlaylistTrackId }));
        }
    }
}
