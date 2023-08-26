using FluentValidation;
using Gymify.Application.Users.Queries.CanDeleteUser;
using Gymify.Application.Users.Queries.UserUIdExistence;
using MediatR;

namespace Gymify.Application.Users.Commands.DeleteUser;

public class DeleteUserValidator: AbstractValidator<DeleteUserCommand>
{
    public DeleteUserValidator(IMediator mediator)
    {
        RuleFor(x => x.UserUid)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .MustAsync(async (x, token) => await mediator.Send(new UserUidExistenceQuery(x), token))
            .WithMessage("User doesnt exist")
            .MustAsync(async (x, token) => await mediator.Send(new CanDeleteUserQuery(x), token))
            .WithMessage("Cannot delete user");
    }
}