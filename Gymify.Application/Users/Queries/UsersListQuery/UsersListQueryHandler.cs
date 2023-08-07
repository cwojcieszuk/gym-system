using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using Gymify.Shared.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Users.Queries.UsersListQuery;

public class UsersListQueryHandler : IRequestHandler<UsersListQuery, PagedResponse<UsersListResponse>>
{
    private readonly IGymifyDbContext _gymifyDbContext;
    private readonly UserManager<AspNetUser> _userManager;

    public UsersListQueryHandler(IGymifyDbContext gymifyDbContext, UserManager<AspNetUser> userManager)
    {
        _gymifyDbContext = gymifyDbContext;
        _userManager = userManager;
    }
    
    public async Task<PagedResponse<UsersListResponse>> Handle(UsersListQuery request, CancellationToken cancellationToken)
    {
        List<AspNetUser> users = await _gymifyDbContext.AspNetUsers.ToListAsync(cancellationToken);
        if (!String.IsNullOrWhiteSpace(request.Name))
        {
            users = users.Where(user =>
            {
                string fullName = user.FirstName + " " + user.LastName;
                return fullName.Contains(request.Name);
            }).ToList();
        }

        if (request.CreationDate.HasValue)
        {
            users = users.Where(user => user.CreatedAt == request.CreationDate).ToList();
        }

        if (!String.IsNullOrWhiteSpace(request.Role))
        {
            IList<AspNetUser> result =  await _userManager.GetUsersInRoleAsync(request.Role);

            users = result.ToList();
        }

        int totalRecords = users.Count;
        int totalPages = totalRecords / request.PageSize + 1;

        users = users.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

        List<UsersListResponse> content = users.Select(user => new UsersListResponse
            (
                user.Id,
                user.FirstName,
                user.LastName,
                Role: _userManager.GetRolesAsync(user).Result[0],
                user.CreatedAt,
                user.Email
            )
        ).ToList();

        return new PagedResponse<UsersListResponse>()
        {   
            Content = content,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalPages = totalPages,
            TotalRecords = totalRecords
        };
    }
}