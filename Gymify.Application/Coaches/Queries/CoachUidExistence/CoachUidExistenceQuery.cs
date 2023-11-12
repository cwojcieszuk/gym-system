using MediatR;

namespace Gymify.Application.Coaches.Queries.CoachUidExistence;

public record CoachUidExistenceQuery(Guid CoachUid) : IRequest<bool>;