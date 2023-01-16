using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.BugTicket;
using AutoMapper;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketsController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;


    public TicketsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] WriteTicketModel ticket)
    {
        var command = new CreateTicket() {
            Name = ticket.Name,
            Asignee = ticket.Asignee,
            Description = ticket.Description,
            Deadline = ticket.Deadline,
            Status = ticket.Status,
            BoardId = ticket.BoardId,
            UserId = ticket.UserId
        };

        var result = await _mediator.Send(command);
        var mappedResult = _mapper.Map<ReadTicketModel>(result);

        return Ok(mappedResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetTicket(id));

        if (result == null)
        {
            return NotFound();
        }

        var mappedResult = _mapper.Map<ReadTicketModel>(result);

        return Ok(mappedResult);
    }

    [HttpGet("id/{boardId}")]
    public async Task<IActionResult> GetByBoardId(Guid boardId)
    {
        var result = await _mediator.Send(new GetTicketByBoardId(boardId));

        if (result == null)
        {
            return NotFound();
        }

        var mappedResult = _mapper.Map<List<ReadTicketModel>>(result);

        return Ok(mappedResult);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllTickets());

        var mappedResult = _mapper.Map<List<ReadTicketModel>>(result);

        return Ok(mappedResult);
    }

    [HttpGet("ticket")]
    public async Task<IActionResult> GetByName([FromQuery(Name = "name")] string name)
    {
        var result = await _mediator.Send(new GetTicketByName(name));

        if (result == null)
        {
            return NotFound();
        }

        var mappedResult = _mapper.Map<List<ReadTicketModel>>(result);

        return Ok(mappedResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteTicket { TicketId = id };
        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] WriteTicketModel ticket)
    {
        var command = new UpdateTicket
        {

            TicketId = id,
            Description = ticket.Description,
            Name = ticket.Name,
            Asignee= ticket.Asignee,
            Deadline= ticket.Deadline,
            Status= ticket.Status,
            BoardId = ticket.BoardId,
            UserId = ticket.UserId
        };

        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}