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
    public class GenreController : ControllerBase
    {
        private readonly IRepository<Genre> _repository;
        public GenreController(IRepository<Genre> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return Ok(await _repository.Read());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre Genre)
        {
            await _repository.Create(Genre);
            return Ok(Genre.GenreId);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<bool>> PutGenre(Genre Genre)
        {
            return Ok(await _repository.Update(Genre));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteGenre(int GenreId)
        {
            return Ok(await _repository.Delete(new Genre { GenreId = GenreId }));
        }
    }
}
