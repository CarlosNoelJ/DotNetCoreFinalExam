using System.Collections.Generic;
using System.Threading.Tasks;
using FinalExam.WebApi.Models;
using FinalExam.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IRepository<Album> _repository;
        public AlbumController(IRepository<Album> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return Ok(await _repository.Read());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            await _repository.Create(album);
            return Ok(album.AlbumId);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<bool>> PutAlbum(Album album)
        {
            return Ok(await _repository.Update(album));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAlbum(int albumId)
        {
            return Ok(await _repository.Delete(new Album { AlbumId = albumId}));
        }
    }
}
