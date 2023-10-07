using Gymify.Application.Coaches.Queries;
using GymifyApi.Extensions;
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
}