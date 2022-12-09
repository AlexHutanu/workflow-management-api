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
            var command = new CreateUser() {
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
            var result = await _mediator.Send(new GetUser(userId));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _mediator.Send(new GetAllUsers());

            return Ok(result);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var command = new DeleteUser { UserId = userId };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] User user)
        {
            var command = new UpdateUser
            {

                UserId = userId,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
