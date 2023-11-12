using System.Net;
using Gymify.Application.Coaches.Queries.CoachUidExistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GymifyApi.Filters;

public class CoachExistenceCheckFilter : IAsyncActionFilter, IOrderedFilter
{
    private readonly IMediator _mediator;

    public CoachExistenceCheckFilter(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public int Order => 1;
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Guid coachUid;

        if (context.ActionArguments.ContainsKey("coachUid"))
        {
            coachUid = Guid.Parse(context.ActionArguments["coachUid"].ToString());
        }
        else
        {
            object body = context.ActionArguments["request"];
            coachUid = Guid.Parse(body.GetType().GetProperty("CoachUid").GetValue(body).ToString());
        }

        if (await _mediator.Send(new CoachUidExistenceQuery(coachUid)))
        {
            await next();
        }

        context.Result = new StatusCodeResult((int)HttpStatusCode.NotFound);
    }
}