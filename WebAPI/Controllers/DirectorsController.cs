using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectorsController : ControllerBase
{
    private readonly IDirectorService _directorService;

    public DirectorsController(IDirectorService directorService)
    {
        _directorService = directorService;
    }

    [HttpGet("[action]")]
    public IActionResult GetAll()
    {
        var result = _directorService.GetAll();
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpGet("[action]")]
    public IActionResult GetByDirectorId(int id)
    {
        var result = _directorService.GetByDirectorId(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpPost("[action]")]
    public IActionResult Add(Director director)
    {
        var result = _directorService.Add(director);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpPut("[action]")]
    public IActionResult Update(Director director)
    {
        var result = _directorService.Update(director);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpDelete("[action]")]
    public IActionResult Delete(Director director)
    {
        var result = _directorService.Delete(director);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}