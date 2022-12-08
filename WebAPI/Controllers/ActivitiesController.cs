using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Activity = Infrastructure.Entities.Activity;

namespace WebAPI.Controllers;


[Route("[controller]")]
[ApiController]
public class ActivitiesController : Controller
{

    private readonly IMediator _mediator;

    public ActivitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromBody] Activity activity)
    {
        var command = new CreateActivityCommand() {
            Id = activity.Id,
            Name = activity.Name,
            Description = activity.Description,
            Owner = activity.Owner,
            TimeCreated= activity.TimeCreated,
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{activityName}")]
    public async Task<IActionResult> Index(Guid activityId)
    {

        var result = await _mediator.Send(new GetActivityQuery(activityId));

        return Ok(result);
    }

}