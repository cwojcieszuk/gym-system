using FluentValidation;
using Gymify.Application.Dictionaries.Queries.PlaceIdExistence;
using Gymify.Domain.Constants.Column;
using MediatR;

namespace Gymify.Application.GroupSessions.Commands.CreateGroupSession;

public class CreateGroupSessionCommandValidator : AbstractValidator<CreateGroupSessionCommand>
{
    public CreateGroupSessionCommandValidator(IMediator mediator)
    {
        RuleFor(x => x.SessionName)
            .MaximumLength(GroupSessionColumnConstants.SessionNameLimit);

        RuleFor(x => x.Description)
            .MaximumLength(GroupSessionColumnConstants.SessionDescriptionLimit);

        RuleFor(x => x.SessionEndDate)
            .GreaterThan(x => x.SessionStartDate);

        RuleFor(x => x.Slots)
            .GreaterThan(0);

        RuleFor(x => x.PlaceId)
            .MustAsync(async (x, token) => await mediator.Send(new PlaceIdExistenceQuery(x), token));
    }
}