using FluentValidation;
using Gymify.Application.Users.Queries.UserUIdExistence;
using MediatR;

namespace Gymify.Application.Profile.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandValidator: AbstractValidator<UpdateUserPasswordCommand>
{
    public UpdateUserPasswordCommandValidator(IMediator mediator)
    {
        RuleFor(x => x.UserUid)
            .MustAsync(async (x, token) => await mediator.Send(new UserUidExistenceQuery(x), token));
        
        
    }
}