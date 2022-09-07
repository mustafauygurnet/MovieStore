using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenresController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet("[action]")]
    public IActionResult GetAll()
    {
        var result = _genreService.GetAll();
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpGet("[action]")]
    public IActionResult GetByGenreId(int id)
    {
        var result = _genreService.GetByGenreId(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpPost("[action]")]
    public IActionResult Add(Genre genre)
    {
        var result = _genreService.Add(genre);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpPut("[action]")]
    public IActionResult Update(Genre genre)
    {
        var result = _genreService.Update(genre);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpDelete("[action]")]
    public IActionResult Delete(Genre genre)
    {
        var result = _genreService.Delete(genre);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}