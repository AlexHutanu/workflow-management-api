using Application.Commands;
using Application.Queries;
using AutoMapper;
using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebAPI.Dtos.BoardDtos;

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
    public async Task<IActionResult> PostBoard([FromBody] BoardPostPutDto board)
    {

        var command = new CreateBoard() {
            Name = board.Name,
            Description = board.Description,

        };

        var result = await _mediator.Send(command);
        var mappedResult = _mapper.Map<BoardGetDto>(result);

        return Ok(mappedResult);
    }

    [HttpGet("{id}")]
    public async  Task<ActionResult<Board>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetBoard(id));

        if (result == null)
        {
            return NotFound();
        }

        var mappedResult = _mapper.Map<BoardGetDto>(result);

        return Ok(mappedResult);
    }

    [HttpGet]
    public async Task<IActionResult> GetBoards()
    {
        var result = await _mediator.Send(new GetAllBoards());
        var mappedResult = _mapper.Map<List<BoardGetDto>>(result);

        return Ok(mappedResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBoard(Guid id)
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
    public async Task<IActionResult> UpdateBoard(Guid id, [FromBody] BoardPostPutDto board)
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