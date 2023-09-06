using FluentValidation;
using Gymify.Application.Templates.Queries.TemplateUidExistenceQuery;
using MediatR;

namespace Gymify.Application.Templates.Commands.DeleteTemplate;

public class DeleteTemplateCommandValidator : AbstractValidator<DeleteTemplateCommand>
{
    public DeleteTemplateCommandValidator(IMediator mediator)
    {
        RuleFor(x => x.TemplateUid)
            .MustAsync(async (x, token) => await mediator.Send(new TemplateUidExistenceQuery(x), token));
    }
}