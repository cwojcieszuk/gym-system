using Gymify.Application.Coaches.Commands.DislikeCoach;
using Gymify.Application.Coaches.Commands.LikeCoach;
using Gymify.Application.Coaches.Commands.SignupForCoach;
using Gymify.Application.Coaches.Queries.GetCoaches;
using Gymify.Application.Coaches.Queries.GetCoachHoursByDate;
using GymifyApi.Extensions;
using GymifyApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;

[ApiController]
[Route("api/coaches")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CoachesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoachesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCoaches([FromQuery] GetCoachesQuery request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        return Ok(await _mediator.Send(request with { UserUid = userUid }));
    }

    [HttpPost("like")]
    [ServiceFilter(typeof(CoachExistenceCheckFilter))]
    public async Task<IActionResult> LikeCoach([FromBody] LikeCoachCommand request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        await _mediator.Send(request with { UserUid = userUid });

        return NoContent();
    }

    [HttpPost("dislike")]
    [ServiceFilter(typeof(CoachExistenceCheckFilter))]
    public async Task<IActionResult> DislikeCoach([FromBody] DislikeCoachCommand request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        await _mediator.Send(request with { UserUid = userUid });

        return NoContent();
    }

    [HttpGet("hours")]
    [ServiceFilter(typeof(CoachExistenceCheckFilter))]
    public async Task<IActionResult> GetCoachHoursByDate([FromQuery] GetCoachHoursByDateQuery request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost("signup")]
    [ServiceFilter(typeof(CoachHourExistenceCheckFilter))]
    public async Task<IActionResult> SignupForCoach([FromBody] SignupForCoachCommand request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        await _mediator.Send(request with { UserUid = userUid });

        return NoContent();
    }
}