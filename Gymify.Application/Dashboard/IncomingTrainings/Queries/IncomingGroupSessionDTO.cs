namespace Gymify.Application.Dashboard.IncomingTrainings.Queries;

public record IncomingGroupSessionDTO(Guid GroupSessionUid, string GroupSessionName, string CoachName, string Place);