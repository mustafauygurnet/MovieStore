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
    public class ActorsOfMovieController : ControllerBase
    {
        private readonly IActorOfMovieService _actorOfMovieService;

        public ActorsOfMovieController(IActorOfMovieService actorOfMovieService)
        {
            _actorOfMovieService = actorOfMovieService;
        }
        
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _actorOfMovieService.GetAll();
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _actorOfMovieService.GetById(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult Add(ActorOfMovie actorOfMovie)
        {
            var result = _actorOfMovieService.Add(actorOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult Update(ActorOfMovie actorOfMovie)
        {
            var result = _actorOfMovieService.Update(actorOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(ActorOfMovie actorOfMovie)
        {
            var result = _actorOfMovieService.Delete(actorOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}
