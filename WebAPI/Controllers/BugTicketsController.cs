using Application.Commands;
using Application.Queries;
using Domain.Entities;
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
    public async Task<IActionResult> Index([FromBody] BugTicket body)
    {
        var command = new CreateBugTicketCommand() { NewBugTicket = body };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{ticketName}")]
    public async Task<IActionResult> Index(string ticketName)
    {
        var result = await _mediator.Send(new GetBugTicketQuery(ticketName));

        return Ok(result);
    }
}