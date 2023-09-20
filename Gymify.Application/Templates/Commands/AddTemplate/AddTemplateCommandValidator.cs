using FluentValidation;
using Gymify.Application.Users.Queries.UserUIdExistence;
using Gymify.Domain.Constants.Column;
using MediatR;

namespace Gymify.Application.Templates.Commands.AddTemplate;

public class AddTemplateCommandValidator: AbstractValidator<AddTemplateCommand>
{
    public AddTemplateCommandValidator(IMediator mediator)
    {
        RuleFor(x => x.UserUid)
            .MustAsync(async (x, token) => await mediator.Send(new UserUidExistenceQuery(x), token))
            .WithMessage("User doesnt exist");

        RuleFor(x => x.TemplateName)
            .MaximumLength(TemplateColumnConstants.TemplateNameLimit);
    }
}