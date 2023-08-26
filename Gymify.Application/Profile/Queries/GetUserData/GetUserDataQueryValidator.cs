using FluentValidation;
using Gymify.Application.Users.Queries.UserUIdExistence;
using MediatR;

namespace Gymify.Application.Profile.Queries.GetUserData;

public class GetUserDataQueryValidator : AbstractValidator<GetUserDataQuery>
{
    public GetUserDataQueryValidator(IMediator mediator)
    {
        RuleFor(x => x.UserUid)
            .MustAsync(async (x, token) => await mediator.Send(new UserUidExistenceQuery(x), token))
            .WithMessage("User doesnt exist");
    }
}