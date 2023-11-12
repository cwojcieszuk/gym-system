namespace Gymify.Application.GroupSessions.Queries.GetGroupSessions;

public class GroupSessionDTO
{
    public Guid GroupSessionUid { get; init; }
    public string Hour { get; init; }
    public string GroupSessionName { get; init; }
    public string Place { get; init; }
    public string CoachName { get; init; }
    public string Duration { get; init; }
    public int AvailableSlots { get; init; }
    public int TakenSlots { get; init; }
    public string Description { get; init; }
    public bool IsBookedIn { get; init; }
}