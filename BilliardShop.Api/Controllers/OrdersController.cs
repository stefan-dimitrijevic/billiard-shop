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
    public class OrdersController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;
        public OrdersController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search, [FromServices] IReadOrdersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get(int id, [FromServices] IReadOrderQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Post([FromBody] OrderDto dto, [FromServices] ICreateOrderCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderDto dto, [FromServices] IUpdateOrderCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }

        //Change Status
        [HttpPatch("changestatus")]
        public IActionResult ChangeStatus([FromBody] ChangeOrderStatusDto dto, [FromServices] IChangeOrderStatusCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }
    }
}
