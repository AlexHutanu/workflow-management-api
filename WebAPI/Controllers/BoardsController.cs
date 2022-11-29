using Application.Commands;
using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[DefaultStatusCode(200)]
public class BoardsController : Controller
{

    private readonly IMediator _mediator;

    public BoardsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromBody] Board body)
    {

        var command = new CreateBoardCommand() { NewBoard = body };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{boardName}")]
    public async  Task<ActionResult<Board>> Index(string boardName)
    {

        var result = await _mediator.Send(new GetBoardQuery(boardName));
        
        return Ok(result);
    }
}