using MediatR;

namespace Gymify.Application.Dashboard.Queries;

public record GetPopularCoachesQuery(Guid UserUid, int Amount) : IRequest<List<PopularCoachDTO>>;