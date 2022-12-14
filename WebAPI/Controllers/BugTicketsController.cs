using Application.Commands;
using Application.Queries;
using Infrastructure.Entities;
using Infrastructure.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos.BugTicketDtos;
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
    public async Task<IActionResult> PostBugTicket([FromBody] BugTicketPostPutDto bugTicket)
    {
        var command = new CreateBugTicket() {
            Name = bugTicket.Name,
            Asignee = bugTicket.Asignee,
            Description= bugTicket.Description,
            Deadline= bugTicket.Deadline,
            Status= bugTicket.Status,
            StepsToReproduce= bugTicket.StepsToReproduce,
            ExpectedResult= bugTicket.ExpectedResult,
            ActualResult= bugTicket.ActualResult,
        };

        var result = await _mediator.Send(command);
        var mappedResult = _mapper.Map<BugTicketGetDto>(result);

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

        var mappedResult = _mapper.Map<BugTicketGetDto>(result);

        return Ok(mappedResult);
    }

    [HttpGet]
    public async Task<IActionResult> GetBugTickets()
    {
        var result = await _mediator.Send(new GetAllBugTickets());

        var mappedResult = _mapper.Map<BugTicketGetDto>(result);

        return Ok(mappedResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBugTicket(Guid id)
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
    public async Task<IActionResult> UpdateBugTicket(Guid id, [FromBody] BugTicketPostPutDto bugTicket)
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
        };

        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}