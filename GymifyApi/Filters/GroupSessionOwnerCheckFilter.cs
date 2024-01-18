using Gymify.Application.GroupSessions.Queries.GroupSessionOwner;
using GymifyApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GymifyApi.Filters
{
    public class GroupSessionOwnerCheckFilter : IAsyncActionFilter, IOrderedFilter
    {
        private readonly IMediator _mediator;

        public GroupSessionOwnerCheckFilter(IMediator mediator)
        {
            _mediator = mediator;
        }

        public int Order => 2;

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

            Guid userUid = Guid.Parse(context.HttpContext.User.GetUserUid());

            if (await _mediator.Send(new GroupSessionOwnerQuery(groupSessionUid, userUid)))
            {
                await next();
            }

            context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
        }
    }
}
