using FluentValidation;
using Gymify.Application.Templates.Queries.TemplateUidExistenceQuery;
using MediatR;

namespace Gymify.Application.Templates.Commands.UpdateTemplate;

public class UpdateTemplateCommandValidator : AbstractValidator<UpdateTemplateCommand>
{
    public UpdateTemplateCommandValidator(IMediator mediator)
    {
        RuleFor(x => x.TemplateUid)
            .MustAsync(async (x, token) => await mediator.Send(new TemplateUidExistenceQuery(x), token))
            .WithMessage("Template doesnt exist");
    }
}