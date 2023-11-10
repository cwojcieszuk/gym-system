using FluentValidation;
using Gymify.Application.GroupSessions.Queries.AreSlotsAvailable;
using Gymify.Application.GroupSessions.Queries.HasClientBookedIn;
using MediatR;

namespace Gymify.Application.GroupSessions.Commands.BookIn;

public class BookInCommandValidator : AbstractValidator<BookInCommand>
{
    public BookInCommandValidator(IMediator mediator)
    {
        RuleFor(x => x)
            .MustAsync(async (x, token) => await mediator.Send(new HasClientBookedInQuery(x.GroupSessionUid, x.UserUid), token))
            .WithMessage("Client has already booked in")
            .MustAsync(async (x, token) => await mediator.Send(new AreSlotsAvailableQuery(x.GroupSessionUid), token))
            .WithMessage("No more slots available");
    }
}