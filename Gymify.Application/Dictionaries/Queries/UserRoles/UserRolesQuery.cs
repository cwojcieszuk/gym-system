using Gymify.Domain.Entities;
using MediatR;

namespace Gymify.Application.Dictionaries.Queries.UserRoles;

public record UserRolesQuery(): IRequest<IEnumerable<UserRoleResponse>>;