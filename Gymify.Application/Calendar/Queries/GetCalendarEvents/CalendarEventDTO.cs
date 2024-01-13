using Gymify.Shared.Enums;

namespace Gymify.Application.Calendar.Queries.GetCalendarEvents;

public class CalendarEventDTO
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Title { get; set; }
    public CalendarEventType EventType { get; set; }
}