using Gymify.Application.Profile.Commands.UpdateCoachData;
using Gymify.Application.Profile.Commands.UpdateUserData;
using Gymify.Application.Profile.Commands.UpdateUserPassword;
using Gymify.Application.Profile.Commands.UploadAvatar;
using Gymify.Application.Profile.Queries.GetUserData;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;

[ApiController]
[Route("api/profile")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{userUid}")]
    public async Task<IActionResult> GetUserData([FromRoute] Guid userUid)
    {
        GetUserDataQuery query = new GetUserDataQuery(userUid);

        return Ok(await _mediator.Send(query));
    }

    [HttpPut]
    [Route("{userUid}/data")]
    public async Task<IActionResult> UpdateUserData([FromRoute] Guid userUid, [FromBody] UpdateUserDataCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut]
    [Route("{userUid}/password")]
    public async Task<IActionResult> UpdateUserPassword([FromRoute] Guid userUid, [FromBody] UpdateUserPasswordCommand command)
    {
        if (command.NewPassword != command.ConfirmPassword)
        {
            return BadRequest("Passwords do not match");
        }

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPost]
    [Route("{userUid}/avatar")]
    public async Task<IActionResult> UploadAvatar([FromRoute] Guid userUid, [FromForm] IFormFile avatar)
    {
        UploadAvatarCommand command = new UploadAvatarCommand(userUid, avatar);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut]
    [Route("{userUid}/coach-data")]
    public async Task<IActionResult> UpdateCoachData(
        [FromRoute] Guid userUid,
        [FromBody] UpdateCoachDataCommand request)
    {
        await _mediator.Send(request);

        return NoContent();
    }
}