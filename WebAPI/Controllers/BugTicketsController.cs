using Application.Commands;
using Application.Queries;
using Infrastructure.Entities;
using Infrastructure.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.BugTicket;
using AutoMapper;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BugTicketsController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;


    public BugTicketsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] WriteBugTicketModel bugTicket)
    {
        var command = new CreateBugTicket() {
            Name = bugTicket.Name,
            Asignee = bugTicket.Asignee,
            Description = bugTicket.Description,
            Deadline = bugTicket.Deadline,
            Status = bugTicket.Status,
            StepsToReproduce = bugTicket.StepsToReproduce,
            ExpectedResult = bugTicket.ExpectedResult,
            ActualResult = bugTicket.ActualResult,
            BoardForeignKey = bugTicket.BoardId
        };

        var result = await _mediator.Send(command);
        var mappedResult = _mapper.Map<ReadBugTicketModel>(result);

        return Ok(mappedResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetBugTicket(id));

        if (result == null)
        {
            return NotFound();
        }

        var mappedResult = _mapper.Map<ReadBugTicketModel>(result);

        return Ok(mappedResult);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllBugTickets());

        var mappedResult = _mapper.Map<List<ReadBugTicketModel>>(result);

        return Ok(mappedResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteBugTicket { BugTicketId = id };
        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] WriteBugTicketModel bugTicket)
    {
        var command = new UpdateBugTicket
        {

            BugTicketId = id,
            Description = bugTicket.Description,
            Name = bugTicket.Name,
            Asignee= bugTicket.Asignee,
            Deadline= bugTicket.Deadline,
            Status= bugTicket.Status,
            StepsToReproduce= bugTicket.StepsToReproduce,
            ExpectedResult= bugTicket.ExpectedResult,
            ActualResult= bugTicket.ActualResult,
            BoardId = bugTicket.BoardId
        };

        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}