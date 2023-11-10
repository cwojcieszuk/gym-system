using MediatR;

namespace Gymify.Application.GroupSessions.Queries.AreSlotsAvailable;

public record AreSlotsAvailableQuery(Guid GroupSessionUid) : IRequest<bool>;