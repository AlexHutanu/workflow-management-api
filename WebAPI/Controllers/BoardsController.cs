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
    public async Task<IActionResult> Index([FromBody] Board board)
    {

        var command = new CreateBoard() {
            Id = board.Id,
            Name = board.Name,
            Description = board.Description,
            NoOfTickets = board.NoOfTickets,
            Owner = board.Owner,
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{boardName}")]
    public async  Task<ActionResult<Board>> Index(Guid boardId)
    {

        var result = await _mediator.Send(new GetBoard(boardId));
        
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetBoards()
    {
        var result = await _mediator.Send(new GetAllBoards());

        return Ok(result);
    }

    [HttpDelete("{boardId}")]
    public async Task<IActionResult> DeleteUser(Guid boardId)
    {
        var command = new DeleteBoard { BoardId = boardId };
        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBoard(Guid boardId, [FromBody] Board board)
    {
        var command = new UpdateBoard
        {

            BoardId = boardId,
            Description = board.Description,
            Name = board.Name,
            NoOfTickets = board.NoOfTickets,
        };

        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}