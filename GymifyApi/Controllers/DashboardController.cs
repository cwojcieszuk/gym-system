using Gymify.Application.Dashboard.PopularExercises.Queries;
using Gymify.Application.Dashboard.Queries;
using GymifyApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;
[ApiController]
[Route("api/dashboard")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DashboardController :ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("popular-coaches")]
    public async Task<IActionResult> GetPopularCoaches([FromQuery] GetPopularCoachesQuery request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());
        GetPopularCoachesQuery query = new GetPopularCoachesQuery(userUid);
        return Ok(await _mediator.Send(query));
    }
    
    [HttpGet]
    [Route("popular-exercises")]
    public async Task<IActionResult> GetPopularExercises([FromQuery] GetPopularCoachesQuery request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());
        GetPopularExercisesQuery query = new GetPopularExercisesQuery(userUid);
        return Ok(await _mediator.Send(query));
    }
}