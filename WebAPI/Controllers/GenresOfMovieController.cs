using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresOfMovieController : ControllerBase
    {
        private IGenreOfMovieService _genreOfMovieService;

        public GenresOfMovieController(IGenreOfMovieService genreOfMovieService)
        {
            _genreOfMovieService = genreOfMovieService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _genreOfMovieService.GetAll();
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _genreOfMovieService.GetById(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult Add(GenreOfMovie genreOfMovie)
        {
            var result = _genreOfMovieService.Add(genreOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult Update(GenreOfMovie genreOfMovie)
        {
            var result = _genreOfMovieService.Update(genreOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(GenreOfMovie genreOfMovie)
        {
            var result = _genreOfMovieService.Delete(genreOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}