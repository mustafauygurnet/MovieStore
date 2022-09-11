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
    public class CustomersOfMovieController : ControllerBase
    {
        private ICustomerOfMovieService _customerOfMovieService;

        public CustomersOfMovieController(ICustomerOfMovieService customerOfMovieService)
        {
            _customerOfMovieService = customerOfMovieService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _customerOfMovieService.GetAll();
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _customerOfMovieService.GetById(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult Add(CustomerOfMovie customerOfMovie)
        {
            var result = _customerOfMovieService.Add(customerOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult Update(CustomerOfMovie customerOfMovie)
        {
            var result = _customerOfMovieService.Update(customerOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(CustomerOfMovie customerOfMovie)
        {
            var result = _customerOfMovieService.Delete(customerOfMovie);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}