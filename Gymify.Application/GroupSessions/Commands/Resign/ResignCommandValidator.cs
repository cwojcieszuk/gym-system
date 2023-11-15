using FluentValidation;
using Gymify.Application.GroupSessions.Queries.HasClientBookedIn;
using MediatR;

namespace Gymify.Application.GroupSessions.Commands.Resign;

public class ResignCommandValidator : AbstractValidator<ResignCommand>
{
    public ResignCommandValidator(IMediator mediator)
    {
        RuleFor(x => x)
            .MustAsync(async (x, token) => await mediator.Send(new HasClientBookedInQuery(x.GroupSessionUid, x.UserUid), token))
            .WithMessage("Client has not booked in");
    }
}