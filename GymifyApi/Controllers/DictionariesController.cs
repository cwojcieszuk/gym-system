using Gymify.Application.Dictionaries.Queries.BodyParts;
using Gymify.Application.Dictionaries.Queries.CoachCategories;
using Gymify.Application.Dictionaries.Queries.DifficultyLevels;
using Gymify.Application.Dictionaries.Queries.Equipments;
using Gymify.Application.Dictionaries.Queries.Targets;
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

    [HttpGet("body-parts")]
    public async Task<IActionResult> GetBodyParts()
    {
        BodyPartsQuery query = new BodyPartsQuery();

        return Ok(await _mediator.Send(query));
    }

    [HttpGet("equipments")]
    public async Task<IActionResult> GetEquipments()
    {
        EquipmentsQuery query = new EquipmentsQuery();

        return Ok(await _mediator.Send(query));
    }

    [HttpGet("targets")]
    public async Task<IActionResult> GetTargets()
    {
        TargetsQuery query = new TargetsQuery();

        return Ok(await _mediator.Send(query));
    }

    [HttpGet("difficulty-levels")]
    public async Task<IActionResult> GetDifficultyLevels()
    {
        GetDifficultyLevelsQuery query = new GetDifficultyLevelsQuery();

        return Ok(await _mediator.Send(query));
    }

    [HttpGet("coach-categories")]
    public async Task<IActionResult> GetCoachCategories()
    {
        GetCoachCategoriesQuery query = new GetCoachCategoriesQuery();

        return Ok(await _mediator.Send(query));
    }
}