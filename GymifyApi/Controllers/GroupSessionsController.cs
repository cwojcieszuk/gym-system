using Gymify.Application.GroupSessions.Commands.BookIn;
using Gymify.Application.GroupSessions.Commands.CreateGroupSession;
using Gymify.Application.GroupSessions.Commands.EditGroupSession;
using Gymify.Application.GroupSessions.Commands.Resign;
using Gymify.Application.GroupSessions.Queries.GetGroupSessions;
using Gymify.Shared.Constants;
using GymifyApi.Extensions;
using GymifyApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;

[ApiController]
[Route("api/group-sessions")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class GroupSessionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroupSessionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetGroupSessions([FromQuery]GetGroupSessionsQuery request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        return Ok(await _mediator.Send(request with { UserUid = userUid }));
    }

    [HttpPost]
    [Route("book-in")]
    [ServiceFilter(typeof(GroupSessionExistenceCheckFilter))]
    public async Task<IActionResult> BookIn([FromBody] BookInCommand request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        await _mediator.Send(request with { UserUid = userUid });

        return NoContent();
    }

    [HttpPost]
    [Route("resign")]
    [ServiceFilter(typeof(GroupSessionExistenceCheckFilter))]
    public async Task<IActionResult> Resign([FromBody] ResignCommand request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        await _mediator.Send(request with { UserUid = userUid });

        return NoContent();
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{RoleConstants.Admin},{RoleConstants.Coach}")]
    public async Task<IActionResult> CreateGroupSession([FromBody] CreateGroupSessionCommand request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        await _mediator.Send(request with { CoachUid = userUid });

        return NoContent();
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = $"{RoleConstants.Admin},{RoleConstants.Coach}")]
    [ServiceFilter(typeof(GroupSessionExistenceCheckFilter))]
    public async Task<IActionResult> EditGroupSession([FromBody] EditGroupSessionCommand request)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        await _mediator.Send(request with { CoachUid = userUid });

        return NoContent();
    }
}