using Gymify.Application.Calendar.Commands.AddCoachHour;
using Gymify.Application.Calendar.Queries.GetCalendarEvents;
using Gymify.Application.Calendar.Queries.GetCoachHours;
using Gymify.Shared.Constants;
using GymifyApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;

[ApiController]
[Route("api/calendar")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CalendarController : ControllerBase
{
    private readonly IMediator _mediator;

    public CalendarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCalendarEvents([FromQuery] GetCalendarEventsQuery request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        return Ok(await _mediator.Send(request with { UserUid = userUid }));
    }

    [HttpPost]    
    [Route("coach-hours")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{RoleConstants.Admin},{RoleConstants.Coach}")]
    public async Task<IActionResult> AddCoachHour([FromBody] AddCoachHourCommand request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        await _mediator.Send(request with { CoachUid = userUid });
        
        return NoContent();
    }

    [HttpGet]
    [Route("coach-hours")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{RoleConstants.Admin},{RoleConstants.Coach}")]
    public async Task<IActionResult> GetCoachHours([FromQuery] GetCoachHoursQuery request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        return Ok(await _mediator.Send(request with { CoachUid = userUid }));
    }
}