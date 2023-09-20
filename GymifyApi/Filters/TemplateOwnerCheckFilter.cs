using System.Net;
using Gymify.Application.Templates.Queries.TemplateOwner;
using GymifyApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GymifyApi.Filters;

public class TemplateOwnerCheckFilter : IAsyncActionFilter, IOrderedFilter
{
    private readonly IMediator _mediator;

    public TemplateOwnerCheckFilter(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public int Order => 2;
    
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

        Guid userUid = Guid.Parse(context.HttpContext.User.GetUserUid());

        if (await _mediator.Send(new TemplateOwnerQuery(templateUid, userUid)))
        {
            await next();
        }
        
        context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
    }
}