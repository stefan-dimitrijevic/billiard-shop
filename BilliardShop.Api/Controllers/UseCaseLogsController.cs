using BilliardShop.Application;
using BilliardShop.Application.Queries;
using BilliardShop.Application.Searches;
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
    public class UseCaseLogsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public UseCaseLogsController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }

        // GET: api/UseCaseLogs
        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseLogSearch search, [FromServices] IReadUseCaseLogsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
    }
}
