using MediatR;

namespace Gymify.Application.Dashboard.Queries;

public record GetPopularCoachesQuery(Guid UserUid) : IRequest<List<PopularCoachDTO>>;