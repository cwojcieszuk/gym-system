using FluentValidation;
using Gymify.Application.Users.Queries.UserUIdExistence;
using MediatR;

namespace Gymify.Application.Users.Commands.DeleteUser;

public class DeleteUserValidator: AbstractValidator<DeleteUserCommand>
{
    public DeleteUserValidator(IMediator mediator)
    {
        RuleFor(x => x.UserUid)
            .MustAsync(async (x, token) => await mediator.Send(new UserUidExistenceQuery(x)))
            ;
    }
}