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
    public class PlaylistController : ControllerBase
    {
        private readonly IRepository<Playlist> _repository;
        public PlaylistController(IRepository<Playlist> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return Ok(await _repository.Read());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist Playlist)
        {
            await _repository.Create(Playlist);
            return Ok(Playlist.PlaylistId);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<bool>> PutPlaylist(Playlist Playlist)
        {
            return Ok(await _repository.Update(Playlist));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeletePlaylist(int PlaylistId)
        {
            return Ok(await _repository.Delete(new Playlist { PlaylistId = PlaylistId }));
        }
    }
}
