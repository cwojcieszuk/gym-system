using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dictionaries.Queries.UserRoles;

public class UserRolesQueryHandler: IRequestHandler<UserRolesQuery, IEnumerable<UserRoleResponse>>
{
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

    public UserRolesQueryHandler(RoleManager<IdentityRole<Guid>> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<IEnumerable<UserRoleResponse>> Handle(UserRolesQuery request, CancellationToken cancellationToken)
    {
        return await _roleManager.Roles.Select(role => new UserRoleResponse(role.Id, role.Name)).ToListAsync(cancellationToken);
    }
}