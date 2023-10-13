using MediatR;

namespace Gymify.Application.Coaches.Queries.GetCoachHoursByDate;

public record GetCoachHoursByDateQuery(Guid CoachUid, DateTime Date): IRequest<IEnumerable<CoachHourDTO>>;