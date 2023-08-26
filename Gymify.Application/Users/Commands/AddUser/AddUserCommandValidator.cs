using FluentValidation;
using Gymify.Domain.Constants.Column;

namespace Gymify.Application.Users.Commands.AddUser;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(UserColumnConstants.FirstNameLimit);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(UserColumnConstants.LastNameLimit);

        RuleFor(x => x.Email)
            .NotEmpty()
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

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}