using MediatR;

namespace Gymify.Application.Calendar.Queries.GetCoachHours;

public record GetCoachHoursQuery(DateTime Date, Guid CoachUid) : IRequest<IEnumerable<CoachHourDTO>>;