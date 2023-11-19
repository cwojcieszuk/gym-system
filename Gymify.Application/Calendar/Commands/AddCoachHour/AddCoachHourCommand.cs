using MediatR;

namespace Gymify.Application.Calendar.Commands.AddCoachHour;

public record AddCoachHourCommand(DateTime StartDate, DateTime EndDate, Guid CoachUid) : IRequest<Unit>;