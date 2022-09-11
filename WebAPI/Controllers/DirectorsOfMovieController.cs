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
    public class DirectorsOfMovieController : ControllerBase
    {
        private IDirectorOfMovieService _directorOfMovieService;

        public DirectorsOfMovieController(IDirectorOfMovieService directorOfMovieService)
        {
            _directorOfMovieService = directorOfMovieService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _directorOfMovieService.GetAll();
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _directorOfMovieService.GetById(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult Add(DirectorOfMovie directorOfMovie)
        {
            var result = _directorOfMovieService.Add(directorOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult Update(DirectorOfMovie directorOfMovie)
        {
            var result = _directorOfMovieService.Update(directorOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(DirectorOfMovie directorOfMovie)
        {
            var result = _directorOfMovieService.Delete(directorOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}