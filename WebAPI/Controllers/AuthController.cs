using Application.Commands;
using AutoMapper;
using Azure.Core;
using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

            var jwt = _jwt.Generate(command.Id);

            return Ok(new
            {
                message = "Success",
                token = jwt
            });

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


            return Ok(new
            {
                message = "Success", token=jwt
            });
        }

        [HttpGet("user")]
        public async Task<IActionResult> User()
        {
            
            try
            {

                if (!Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
                
                  return Unauthorized();
                
                string token = Request.Headers["Authorization"];

                var jwt = token.Split(" ")[1];

                var verifiedToken = _jwt.Verify(jwt);

                Guid userId = Guid.Parse(verifiedToken.Issuer);

                var user = await _repository.GetById(userId);


                return Ok(user);

            }catch (Exception e)
            {
                return Unauthorized();
            }
        }
    }
}
