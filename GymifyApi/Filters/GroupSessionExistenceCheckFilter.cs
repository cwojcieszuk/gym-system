using System.Net;
using Gymify.Application.GroupSessions.Queries.GroupSessionUidExistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GymifyApi.Filters;

public class GroupSessionExistenceCheckFilter : IAsyncActionFilter, IOrderedFilter
{
    private readonly IMediator _mediator;

    public GroupSessionExistenceCheckFilter(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Guid groupSessionUid;

        if (context.ActionArguments.ContainsKey("groupSessionUid"))
        {
            groupSessionUid = Guid.Parse(context.ActionArguments["groupSessionUid"].ToString());
        }
        else
        {
            object body = context.ActionArguments["request"];
            groupSessionUid = Guid.Parse(body.GetType().GetProperty("GroupSessionUid").GetValue(body).ToString());
        }

        if (await _mediator.Send(new GroupSessionUidExistenceQuery(groupSessionUid)))
        {
            await next();
        }

        context.Result = new StatusCodeResult((int)HttpStatusCode.NotFound);
    }

    public int Order => 1;
}