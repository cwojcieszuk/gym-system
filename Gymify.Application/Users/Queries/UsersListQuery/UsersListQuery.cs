using Gymify.Shared.Wrappers;
using MediatR;

namespace Gymify.Application.Users.Queries.UsersListQuery;

public record UsersListQuery(string? Name, string? Role, DateTime? BirthDate, int PageNumber, int PageSize) : IRequest<PagedResponse<UsersListResponse>>;


