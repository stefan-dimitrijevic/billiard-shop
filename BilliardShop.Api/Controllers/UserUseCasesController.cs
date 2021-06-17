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
    public class UserUseCasesController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public UserUseCasesController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }

        // GET: api/UserUseCases
        [HttpGet]
        public IActionResult Get([FromQuery] UserUseCaseSearch search, [FromServices] IReadUserUseCasesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST: api/UserUseCases
        [HttpPost]
        public IActionResult Post([FromBody] UserUseCaseDto dto, [FromServices] ICreateUserUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/UserUseCases/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserUseCaseDto dto, [FromServices] IUpdateUserUseCaseCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
