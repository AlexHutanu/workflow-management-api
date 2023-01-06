using Application.Commands;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Auth;
using WebAPI.Models.User;
using WebAPI.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly Jwt _jwt;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(IUserRepository repository, Jwt jwt, IMediator mediator, IMapper mapper)
        {
            _repository = repository;
            _jwt = jwt;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] Register register) {

            var command = new CreateUser()
            {
                Name = register.Name,
                Email = register.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password),
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<ReadUserModel>(result);

            return Ok(mappedResult);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {

            var user = _repository.GetByEmail(login.Email);

            if (user == null) 
                return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(login.Password, user.Password)) 
                return BadRequest(new { message = "Invalid Credentials" });

            var jwt = _jwt.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "Success"
            });
        }

        [HttpGet("user")]
        public async Task<IActionResult> User()
        {

            try
            {

                var jwt = Request.Cookies["jwt"];

                var token = _jwt.Verify(jwt);

                Guid userId = Guid.Parse(token.Issuer);

                var user = await _repository.GetById(userId);

                return Ok(user);
            }catch (Exception e)
            {
                return Unauthorized();
            }
        }
    }
}
