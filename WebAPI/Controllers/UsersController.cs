using Application.Commands;
using Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Auth;
using WebAPI.Models.User;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;   
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WriteUserModel user)
        {
            var command = new CreateUser() {
                Name = user.Name,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<ReadUserModel>(result);

            return Ok(mappedResult);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetUser(id));

            if (result == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<ReadUserModel>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllUsers());

            var mappedResult = _mapper.Map<List<ReadUserModel>>(result);

            return Ok(mappedResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUser { UserId = id };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] WriteUserModel user)
        {
            var command = new UpdateUser
            {

                UserId = id,
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
