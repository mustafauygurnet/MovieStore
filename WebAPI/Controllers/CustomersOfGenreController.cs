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
    public class CustomersOfGenreController : ControllerBase
    {
        private readonly ICustomerOfGenreService _customerOfGenreService;

        public CustomersOfGenreController(ICustomerOfGenreService customerOfGenreService)
        {
            _customerOfGenreService = customerOfGenreService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _customerOfGenreService.GetAll();
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _customerOfGenreService.GetById(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult Add(CustomerOfGenre customerOfGenre)
        {
            var result = _customerOfGenreService.Add(customerOfGenre);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult Update(CustomerOfGenre customerOfGenre)
        {
            var result = _customerOfGenreService.Update(customerOfGenre);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(CustomerOfGenre customerOfGenre)
        {
            var result = _customerOfGenreService.Delete(customerOfGenre);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}