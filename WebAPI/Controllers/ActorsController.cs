using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorsController : ControllerBase
{
    private readonly IActorService _actorService;

    public ActorsController(IActorService actorService)
    {
        _actorService = actorService;
    }

    [HttpGet("[action]")]
    public IActionResult GetAll()
    {
        var result = _actorService.GetAll();
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpGet("[action]")]
    public IActionResult GetByActorId(int id)
    {
        var result = _actorService.GetByActorId(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpPost("[action]")]
    public IActionResult Add(Actor actor)
    {
        var result = _actorService.Add(actor);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpPut("[action]")]
    public IActionResult Update(Actor actor)
    {
        var result = _actorService.Update(actor);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpDelete("[action]")]
    public IActionResult Delete(Actor actor)
    {
        var result = _actorService.Delete(actor);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}