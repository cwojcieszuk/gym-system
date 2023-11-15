using MediatR;

namespace Gymify.Application.GroupSessions.Commands.CreateGroupSession;

public record CreateGroupSessionCommand(string SessionName, int Slots, DateTime SessionStartDate, DateTime SessionEndDate, string Description, int PlaceId, Guid CoachUid) : IRequest<Unit>;