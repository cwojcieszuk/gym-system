using MediatR;

namespace Gymify.Application.GroupSessions.Queries.GroupSessionUidExistence;

public record GroupSessionUidExistenceQuery(Guid GroupSessionUid) : IRequest<bool>;