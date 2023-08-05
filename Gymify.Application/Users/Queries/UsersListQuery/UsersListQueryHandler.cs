using Gymify.Application.Interfaces;
using Gymify.Application.Wrappers;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Users.Queries.UsersListQuery;

public class UsersListQueryHandler : IRequestHandler<UsersListQuery, PagedResponse<UsersListResponse>>
{

    private readonly IGymifyDbContext _gymifyDbContext;

    public UsersListQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<PagedResponse<UsersListResponse>> Handle(UsersListQuery request, CancellationToken cancellationToken)
    {
        List<AspNetUser> users = await _gymifyDbContext.AspNetUsers.ToListAsync();
        if (!String.IsNullOrWhiteSpace(request.Name))
        {
            users.Where(user =>
            {
                string fullName = user.FirstName + " " + user.LastName;
                return fullName.Contains(request.Name);
            });
        }

        if (!String.IsNullOrWhiteSpace(request.CreationDate.ToString()))
        {
            users.Where(user =>
            {
                return DateTime.Compare(user.CreatedAt, request.CreationDate) == 0;
            });
        }
        
        int totalRecords = users.Count();
        int totalPages = totalRecords / request.PageSize + 1;

        users = users.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

        List<UsersListResponse> content = users.Select(user => 
            new UsersListResponse(user.Id, user.FirstName, user.LastName, "rola", user.CreatedAt, user.Email)
        {
            UserUid = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = "rola",
            RegisterDate = user.CreatedAt,
            Email = user.Email
        }).ToList();

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