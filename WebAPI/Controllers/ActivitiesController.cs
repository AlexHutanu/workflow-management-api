using Application.Commands;
using Application.Queries;
using Infrastructure.Repositories;
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
        var command = new CreateActivity() {
            Id = activity.Id,
            Name = activity.Name,
            Description = activity.Description,
            Owner = activity.Owner,
            TimeCreated= activity.TimeCreated,
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetActivities()
    {
        var result = await _mediator.Send(new GetAllActivities());

        return Ok(result);
    }

    [HttpGet("{activityName}")]
    public async Task<IActionResult> Index(Guid activityId)
    {

        var result = await _mediator.Send(new GetActivity(activityId));

        return Ok(result);
    }

    [HttpDelete("{activityId}")]
    public async Task<IActionResult> DeleteActivity(Guid activityId)
    {
        var command = new DeleteActivity { ActivityId = activityId };
        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{activityId}")]
    public async Task<IActionResult> UpdateActivity(Guid activityId, [FromBody] Activity activity)
    {
        var command = new UpdateActivity
        {

            ActivityId = activityId,
            Description = activity.Description,
            Name = activity.Name,
        };

        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

}