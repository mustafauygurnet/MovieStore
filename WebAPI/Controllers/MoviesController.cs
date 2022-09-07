using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("[action]")]
    public IActionResult GetAll()
    {
        var result = _movieService.GetAll();
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("[action]")]
    public IActionResult GetByMovieId(int id)
    {
        var result = _movieService.GetByMovieId(id);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("[action]")]
    public IActionResult Add(Movie movie)
    {
        var result = _movieService.Add(movie);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut("[action]")]
    public IActionResult Update(Movie movie)
    {
        var result = _movieService.Update(movie);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("[action]")]
    public IActionResult Delete(Movie movie)
    {
        var result = _movieService.Delete(movie);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}