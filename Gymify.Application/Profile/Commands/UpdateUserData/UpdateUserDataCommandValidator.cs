using FluentValidation;
using Gymify.Application.Users.Queries.UserUIdExistence;
using MediatR;

namespace Gymify.Application.Profile.Commands.UpdateUserData;

public class UpdateUserDataCommandValidator: AbstractValidator<UpdateUserDataCommand>
{
    public UpdateUserDataCommandValidator(IMediator mediator)
    {
        RuleFor(x => x.UserUid)
            .MustAsync(async (x, token) => await mediator.Send(new UserUidExistenceQuery(x), token))
            .WithMessage("User doesnt exist");
    }
}