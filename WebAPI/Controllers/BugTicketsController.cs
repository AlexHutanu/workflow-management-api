using Application.Commands;
using Application.Queries;
using Infrastructure.Entities;
using Infrastructure.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BugTicketsController : Controller
{
    private readonly IMediator _mediator;


    public BugTicketsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromBody] BugTicket bugTicket)
    {
        var command = new CreateBugTicket() {
            Id = bugTicket.Id,
            Name = bugTicket.Name,
            Asignee = bugTicket.Asignee,
            Reporter= bugTicket.Reporter,
            Description= bugTicket.Description,
            Deadline= bugTicket.Deadline,
            Status= bugTicket.Status,
            StepsToReproduce= bugTicket.StepsToReproduce,
            ExpectedResult= bugTicket.ExpectedResult,
            ActualResult= bugTicket.ActualResult,
        };

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{ticketName}")]
    public async Task<IActionResult> Index(Guid ticketId)
    {
        var result = await _mediator.Send(new GetBugTicket(ticketId));

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetBugTickets()
    {
        var result = await _mediator.Send(new GetAllBugTickets());

        return Ok(result);
    }

    [HttpDelete("{bugTicketId}")]
    public async Task<IActionResult> DeleteUser(Guid bugTicketId)
    {
        var command = new DeleteBugTicket { BugTicketId = bugTicketId };
        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{bugTicketId}")]
    public async Task<IActionResult> UpdateBugTicket(Guid bugTicketId, [FromBody] BugTicket bugTicket)
    {
        var command = new UpdateBugTicket
        {

            BugTicketId = bugTicketId,
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