using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Users.Queries.UserUIdExistence;

public class UserUidExistenceQueryHandler: IRequestHandler<UserUidExistenceQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public UserUidExistenceQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<bool> Handle(UserUidExistenceQuery request, CancellationToken cancellationToken)
    {
        return await _gymifyDbContext.AspNetUsers.AnyAsync(user => user.Id == request.UserUid, cancellationToken);
    }
}