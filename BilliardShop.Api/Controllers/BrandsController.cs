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
    public class BrandsController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;
        public BrandsController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }

        // GET: api/Brands
        [HttpGet]
        public IActionResult Get([FromQuery] BrandSearch search, [FromServices] IReadBrandsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Brands/5
        [HttpGet("{id}", Name = "GetBrand")]
        public IActionResult Get(int id, [FromServices] IReadBrandQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Brands
        [HttpPost]
        public IActionResult Post([FromBody] BrandDto dto, [FromServices] ICreateBrandCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Brands/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BrandDto dto, [FromServices] IUpdateBrandCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }

}
