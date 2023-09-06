using Gymify.Application.Templates.Commands.AddTemplate;
using Gymify.Application.Templates.Commands.DeleteTemplate;
using Gymify.Application.Templates.Commands.ShareTemplate;
using Gymify.Application.Templates.Queries.GetCommunityTemplates;
using Gymify.Application.Templates.Queries.GetPersonalTemplates;
using Gymify.Application.Templates.Queries.GetTemplate;
using Gymify.Shared.Params;
using GymifyApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymifyApi.Controllers;

[ApiController]
[Route("api/templates")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class TemplatesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TemplatesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("personal")]
    public async Task<IActionResult> GetPersonalTemplates([FromQuery] PageParameters parameters)
    {
        string userUid = User.GetUserUid();

        if (userUid is null)
        {
            return Forbid();
        }

        GetPersonalTemplatesQuery query = new GetPersonalTemplatesQuery(Guid.Parse(userUid), parameters.PageNumber, parameters.PageSize);

        return Ok(await _mediator.Send(query));
    }

    [HttpGet]
    [Route("community")]
    public async Task<IActionResult> GetCommunityTemplates([FromQuery] PageParameters parameters)
    {
        GetCommunityTemplatesQuery query = new GetCommunityTemplatesQuery(parameters.PageNumber, parameters.PageSize);

        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    [Route("{templateUid}/share")]
    public async Task<IActionResult> ShareTemplate([FromRoute] ShareTemplateCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> AddTemplate([FromBody] AddTemplateCommand command)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }
        
        await _mediator.Send(command with { UserUid = userUid });

        return NoContent();
    }

    [HttpGet]
    [Route("{templateUid}")]
    public async Task<IActionResult> GetTemplate([FromRoute] GetTemplateCommand command)
    {
        Guid userUid = Guid.Parse(User.GetUserUid());

        if (userUid == null)
        {
            return Forbid();
        }

        return Ok(await _mediator.Send(command with { UserUid = userUid }));
    }

    [HttpDelete]
    [Route("{templateUid}")]
    //TemplateOwnerCheckFilter
    public async Task<IActionResult> DeleteTemplate([FromRoute] DeleteTemplateCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
}