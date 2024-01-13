using MediatR;

namespace Gymify.Application.Calendar.Queries.GetCalendarEvents;

public record GetCalendarEventsQuery(DateTime Date, Guid UserUid) : IRequest<IEnumerable<CalendarEventDTO>>;