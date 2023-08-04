using FluentValidation;
using Gymify.Application.Auth.Queries.UserExistence;
using Gymify.Application.Auth.Queries.UserPassword;
using MediatR;

namespace Gymify.Application.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator(IMediator mediator)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .MustAsync(async (email, token) => await mediator.Send(new UserExistenceQuery(email), token))
            .WithMessage("User doesn't exist");

        RuleFor(x => x.Password)
            .NotEmpty();

        RuleFor(x => x)
            .MustAsync(async (req, token) => await mediator.Send(new UserPasswordQuery(req.Email, req.Password), token))
            .WithMessage("Email or password doesn't match");
    }
}