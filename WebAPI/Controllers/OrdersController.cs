using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("[action]")]
    public IActionResult GetAll()
    {
        var result = _orderService.GetAll();
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpGet("[action]")]
    public IActionResult GetByOrderId(int id)
    {
        var result = _orderService.GetByOrderId(id);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpPost("[action]")]
    public IActionResult Add(Order order)
    {
        var result = _orderService.Add(order);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpPut("[action]")]
    public IActionResult Update(Order order)
    {
        var result = _orderService.Update(order);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
    
    [HttpDelete("[action]")]
    public IActionResult Delete(Order order)
    {
        var result = _orderService.Delete(order);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}