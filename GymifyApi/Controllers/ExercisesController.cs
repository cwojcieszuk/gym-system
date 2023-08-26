using Gymify.Application.Exercises.Commands.DislikeExercise;
using Gymify.Application.Exercises.Commands.LikeExercise;
using Gymify.Application.Exercises.Queries.GetExercisesList;
using GymifyApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;

[ApiController]
[Route("api/exercises")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        Guid userUid = Guid.Parse(User.GetUserUid());

        return Ok(await _mediator.Send(query with { UserUid = userUid }));
    }

    [HttpPost("like")]
    public async Task<IActionResult> LikeExercise([FromBody] LikeExerciseCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPost("dislike")]
    public async Task<IActionResult> DislikeExercise([FromBody] DislikeExerciseCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
}