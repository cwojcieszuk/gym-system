using Gymify.Application.GroupSessions.Commands.BookIn;
using Gymify.Application.GroupSessions.Queries.GetGroupSessions;
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
}