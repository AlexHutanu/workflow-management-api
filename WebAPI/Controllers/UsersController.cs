using Application.Commands;
using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] User user)
        {
            var command = new CreateUserCommand() {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("username")]
        public async Task<IActionResult> Index(Guid userId)
        {
            var result = await _mediator.Send(new GetUserQuery(userId));

            return Ok(result);
        }

    }
}
