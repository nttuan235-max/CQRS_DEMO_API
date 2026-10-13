using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CQRS_DEMO.Features.Users.Commands;
using CQRS_DEMO.Features.Users.Queries;
namespace CQRS_DEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdQuery(string id)
        {
            var query = new GetUserByIdQuery { UserID = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
