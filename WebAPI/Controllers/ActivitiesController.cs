using Application.Commands;
using Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.ActivityDtos;

namespace WebAPI.Controllers;


[Route("[controller]")]
[ApiController]
public class ActivitiesController : Controller
{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ActivitiesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] WriteActivityModel activity)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Activity command = new() {
            Name = activity.Name,
            Description = activity.Description,
        };

        var result = await _mediator.Send(command);
        var mappedResult = _mapper.Map<ReadActivityModel>(result);

        return Ok(mappedResult);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllActivities());
        var mappedResult = _mapper.Map<List<ReadActivityModel>>(result);

        return Ok(mappedResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {

        var result = await _mediator.Send(new GetActivity(id));

        if (result == null)
        {
            return NotFound();
        }

        var mappedResult = _mapper.Map<ReadActivityModel>(result);

        return Ok(mappedResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteActivity { ActivityId = id };
        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] WriteActivityModel activity)
    {
        var command = new UpdateActivity
        {
            Description = activity.Description,
            Name = activity.Name,
        };

        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

}