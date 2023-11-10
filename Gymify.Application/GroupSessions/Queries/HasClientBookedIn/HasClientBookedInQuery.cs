using MediatR;

namespace Gymify.Application.GroupSessions.Queries.HasClientBookedIn;

public record HasClientBookedInQuery(Guid GroupSessionUid, Guid UserUid) : IRequest<bool>;