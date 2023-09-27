using Gymify.Application.Trainings.Commands.AddTreining;
using Gymify.Application.Trainings.Commands.UpdateTraining;
using Gymify.Application.Trainings.Queries.GetTraining;
using Gymify.Shared.Params;
using GymifyApi.Extensions;
using GymifyApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;
[ApiController]
[Route("api/trainings")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class TrainingController : ControllerBase
{
    private readonly IMediator _mediator;

    public TrainingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrainings([FromQuery] PageParameters parameters)
    {
        string userUid = User.GetUserUid();

        if (userUid is null)
        {
            return Forbid();
        }

        GetTrainingQuery query = new GetTrainingQuery(Guid.Parse(userUid), parameters.PageNumber, parameters.PageSize);
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> AddTraining([FromBody] AddTrainingCommand command)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());
        if (userUid == null)
        {
            return Forbid();
        }

        await _mediator.Send(command with { UserUid = userUid });
        return NoContent();
    }

    [HttpPut]
    [Route("{trainingUid}")]
    [ServiceFilter(typeof(TrainingExistenceCheckFilter))]
    public async Task<IActionResult> UpdateTraining([FromRoute] Guid trainingUid,
        [FromBody] UpdateTrainingCommand request)
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