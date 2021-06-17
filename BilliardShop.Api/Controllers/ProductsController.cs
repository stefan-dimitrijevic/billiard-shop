using BilliardShop.Application;
using BilliardShop.Application.Commands;
using BilliardShop.Application.DataTransfer;
using BilliardShop.Application.Queries;
using BilliardShop.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BilliardShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public ProductsController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult Get([FromQuery] ProductSearch search, [FromServices] IReadProductsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id, [FromServices] IReadProductQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromForm] ProductDto dto, [FromServices] ICreateProductCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] ProductDto dto, [FromServices] IUpdateProductCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProductCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
