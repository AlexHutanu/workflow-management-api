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
        var command = new CreateBugTicketCommand() {
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
        var result = await _mediator.Send(new GetBugTicketQuery(ticketId));

        return Ok(result);
    }
}