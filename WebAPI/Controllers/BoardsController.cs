using Application.Commands;
using Application.Queries;
using AutoMapper;
using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using WebAPI.Models.Board;

namespace WebAPI.Controllers;   

[ApiController]
[Route("[controller]")]

public class BoardsController : Controller
{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BoardsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] WriteBoardModel board)
    {
        var command = new CreateBoard() {
            Name = board.Name,
            Description = board.Description,
            UserId = board.UserId

        };

        var result = await _mediator.Send(command);
        var mappedResult = _mapper.Map<ReadBoardModel>(result);

        return Ok(mappedResult);
    }

    [HttpGet("{id}")]
    public async  Task<ActionResult<BoardEntity>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetBoard(id));

        if (result == null)
        {
            return NotFound();
        }

        var mappedResult = _mapper.Map<ReadBoardModel>(result);

        return Ok(mappedResult);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllBoards());

        if (result == null)
        {
            return NotFound();
        }

        var mappedResult = _mapper.Map<List<ReadBoardModel>>(result);

        return Ok(mappedResult);
    }

    [HttpGet("board")]
    public async Task<IActionResult> GetByName([FromQuery(Name = "name")] string name)
    {
        var result = await _mediator.Send(new GetBoardByName(name));

        if (result == null)
        {
            return NotFound();
        }

        var mappedResult = _mapper.Map<List<ReadBoardModel>>(result);

        return Ok(mappedResult);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteBoard { BoardId = id };
        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] WriteBoardModel board)
    {
        var command = new UpdateBoard
        {

            BoardId = id,
            Description = board.Description,
            Name = board.Name,
        };

        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}