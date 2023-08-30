using FluentValidation;
using Gymify.Application.Templates.Queries.IsTemplateSharedQuery;
using Gymify.Application.Templates.Queries.TemplateUidExistenceQuery;
using MediatR;

namespace Gymify.Application.Templates.Commands.ShareTemplate;

public class ShareTemplateCommandValidator: AbstractValidator<ShareTemplateCommand>
{
    public ShareTemplateCommandValidator(IMediator mediator)
    {
        RuleFor(x => x.TemplateUid)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .MustAsync(async (x, token) => await mediator.Send(new TemplateUidExistenceQuery(x), token))
            .WithMessage("Template doesn't exist")
            .MustAsync(async (x, token) => await mediator.Send(new IsTemplateSharedQuery(x), token))
            .WithMessage("Template is already shared!");
    }
}