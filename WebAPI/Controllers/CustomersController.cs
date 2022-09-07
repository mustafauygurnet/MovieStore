using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("[action]")]
    public IActionResult GetAll()
    {
        var result = _customerService.GetAll();
        if (!result.Success) return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("[action]")]
    public IActionResult GetByCustomerId(int id)
    {
        var result = _customerService.GetByCustomerId(id);
        if (!result.Success) return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("[action]")]
    public IActionResult Add(Customer customer)
    {
        var result = _customerService.Add(customer);
        if (!result.Success) return BadRequest(result);

        return Ok(result);
    }

    [HttpPut("[action]")]
    public IActionResult Update(Customer customer)
    {
        var result = _customerService.Update(customer);
        if (!result.Success) return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("[action]")]
    public IActionResult Delete(Customer customer)
    {
        var result = _customerService.Delete(customer);
        if (!result.Success) return BadRequest(result);

        return Ok(result);
    }
}