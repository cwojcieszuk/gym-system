using System.Net;
using Gymify.Application.Trainings.Queries.TrainingUidExistenceQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GymifyApi.Filters;

public class TrainingExistenceCheckFilter : IAsyncActionFilter, IOrderedFilter
{
    private readonly IMediator _mediator;

    public TrainingExistenceCheckFilter(IMediator mediator)
    {
        _mediator = mediator;
    }

    public int Order => 1;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Guid trainingUid;

        if (context.ActionArguments.ContainsKey("trainingUid"))
        {
            trainingUid = Guid.Parse(context.ActionArguments["trainingUid"].ToString());
        }
        else
        {
            object body = context.ActionArguments["request"];
            trainingUid = Guid.Parse(body.GetType().GetProperty("TrainingUid").GetValue(body).ToString());
        }

        if (await _mediator.Send(new TrainingUidExistenceQuery(trainingUid)))
        {
            await next();
        }

        context.Result = new StatusCodeResult((int)HttpStatusCode.NotFound);
    }
}