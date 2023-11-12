using MediatR;

namespace Gymify.Application.Coaches.Queries.CoachHourUidExistence;

public record CoachHourUidExistenceQuery(Guid CoachHourUid) : IRequest<bool>;