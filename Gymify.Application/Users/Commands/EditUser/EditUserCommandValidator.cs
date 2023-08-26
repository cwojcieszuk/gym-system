using FluentValidation;
using Gymify.Application.Auth.Queries.UserExistence;
using Gymify.Domain.Constants.Column;
using MediatR;

namespace Gymify.Application.Users.Commands.EditUser;

public class EditUserCommandValidator: AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator(IMediator mediator)
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(UserColumnConstants.FirstNameLimit);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(UserColumnConstants.LastNameLimit);

        RuleFor(x => x.Email)
            .NotEmpty()
            .MustAsync(async (x, token) => await mediator.Send(new UserExistenceQuery(x), token))
            .EmailAddress()
            .MaximumLength(UserColumnConstants.EmailLimit);

        RuleFor(x => x.Gender)
            .NotEmpty()
            .MaximumLength(UserColumnConstants.GenderLimit);

        RuleFor(x => x.Login)
            .NotEmpty()
            .MaximumLength(UserColumnConstants.UsernameLimit);

        RuleFor(x => x.BirthDate)
            .NotEmpty();

        RuleFor(x => x.PhoneNumber)
            .NotEmpty();
    }
}