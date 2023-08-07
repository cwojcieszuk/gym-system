using Gymify.Shared.Wrappers;
using MediatR;

namespace Gymify.Application.Users.Queries.UsersListQuery;

public record UsersListQuery(string? Name, string? Role, DateTime? CreationDate, int PageNumber, int PageSize) : IRequest<PagedResponse<UsersListResponse>>;


