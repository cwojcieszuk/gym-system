using Gymify.Application.Auth.Commands.Login;
using Gymify.Application.Auth.Commands.Logout;
using Gymify.Application.Auth.Commands.Refresh;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody]LoginCommand loginCommand)
    {
        AuthResponse authResult = await _mediator.Send(loginCommand);

        return Ok(authResult);
    }

    [HttpPost]
    [Route("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        AuthResponse? authResult = await _mediator.Send(command);

        if (authResult is null)
        {
            return Forbid();
        }

        return Ok(authResult);
    }

    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
}