using MediatR;

namespace Gymify.Application.Dashboard.IncomingTrainings.Queries;

public record GetIncomingGroupSessionsQuery(Guid UserUid, int Amount) : IRequest<List<IncomingGroupSessionDTO>>;