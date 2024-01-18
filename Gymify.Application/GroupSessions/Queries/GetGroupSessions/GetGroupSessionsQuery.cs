using Gymify.Shared.Wrappers;
using MediatR;

namespace Gymify.Application.GroupSessions.Queries.GetGroupSessions;

public record GetGroupSessionsQuery(DateTime? Date, Guid UserUid, int? CategoryId, Guid? CoachUid, string? Name, int PageNumber, int PageSize) : IRequest<PagedResponse<GroupSessionDTO>>;
