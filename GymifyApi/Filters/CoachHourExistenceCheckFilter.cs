using System.Net;
using Gymify.Application.Coaches.Queries.CoachHourUidExistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GymifyApi.Filters;

public class CoachHourExistenceCheckFilter : IAsyncActionFilter, IOrderedFilter
{
    private readonly IMediator _mediator;

    public CoachHourExistenceCheckFilter(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public int Order => 1;
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Guid coachHourUid;

        if (context.ActionArguments.ContainsKey("coachUid"))
        {
            coachHourUid = Guid.Parse(context.ActionArguments["coachHourUid"].ToString());
        }
        else
        {
            object body = context.ActionArguments["request"];
            coachHourUid = Guid.Parse(body.GetType().GetProperty("CoachHourUid").GetValue(body).ToString());
        }

        if (await _mediator.Send(new CoachHourUidExistenceQuery(coachHourUid)))
        {
            await next();
        }

        context.Result = new StatusCodeResult((int)HttpStatusCode.NotFound);
    }
}