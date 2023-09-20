using System.Net;
using Gymify.Application.Templates.Queries.TemplateUidExistenceQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GymifyApi.Filters;

public class TemplateExistenceCheckFilter : IAsyncActionFilter, IOrderedFilter
{
    private readonly IMediator _mediator;

    public TemplateExistenceCheckFilter(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public int Order => 1;
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Guid templateUid;

        if (context.ActionArguments.ContainsKey("templateUid"))
        {
            templateUid = Guid.Parse(context.ActionArguments["templateUid"].ToString());
        }
        else
        {
            object body = context.ActionArguments["request"];
            templateUid = Guid.Parse(body.GetType().GetProperty("TemplateUid").GetValue(body).ToString());
        }

        if (await _mediator.Send(new TemplateUidExistenceQuery(templateUid)))
        {
            await next();
        }

        context.Result = new StatusCodeResult((int)HttpStatusCode.NotFound);
    }
}