using Gymify.Application.Exercises.Queries.GetExercisesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;

[ApiController]
[Route("api/exercises")]
public class ExercisesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExercisesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetExercises([FromQuery] GetExercisesListQuery query)
    {
        return Ok(await _mediator.Send(query));
    }
}