using Gymify.Application.Auth.Commands.Login;
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
    public async Task<IActionResult> Login([FromBody]LoginCommand loginCommand)
    {
        var authResult = await _mediator.Send(loginCommand);
        
        if (authResult == null)
        {
            return BadRequest();
        }
        
        return Ok(authResult);
    } 
}