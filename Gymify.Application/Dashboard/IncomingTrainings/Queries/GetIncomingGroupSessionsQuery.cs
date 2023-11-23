using MediatR;

namespace Gymify.Application.Dashboard.IncomingTrainings.Queries;

public record GetIncomingGroupSessionsQuery(Guid UserUid) : IRequest<List<IncomingGroupSessionDTO>>;