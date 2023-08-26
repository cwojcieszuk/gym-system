using Gymify.Application.Dictionaries.Queries.UserRoles;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;

[ApiController]
[Route("api/dictionaries")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DictionariesController: ControllerBase
{
    private readonly IMediator _mediator;

    public DictionariesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("user-roles")]
    public async Task<IActionResult> GetUserRoles()
    {
        UserRolesQuery query = new UserRolesQuery();

        return Ok(await _mediator.Send(query));
    }
}