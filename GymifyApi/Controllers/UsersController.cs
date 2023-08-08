using Gymify.Application.Users.Commands.AddUser;
using Gymify.Application.Users.Commands.EditUser;
using Gymify.Application.Users.Queries.UsersListQuery;
using Gymify.Shared.Params;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;

[ApiController]
[Route("api/users")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] UsersListQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("{userUid}")]
    public async Task<IActionResult> EditUser([FromRoute] Guid userUid, [FromBody] EditUserCommand command)
    {
        await _mediator.Send(command);
        
        return NoContent();
    }
}