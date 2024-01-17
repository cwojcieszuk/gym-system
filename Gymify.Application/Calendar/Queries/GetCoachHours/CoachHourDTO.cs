namespace Gymify.Application.Calendar.Queries.GetCoachHours;

public record CoachHourDTO(Guid CoachHourUid, Guid CoachUid, Guid? ClientUid, string? ClientName, DateTime StartDate, DateTime EndDate);