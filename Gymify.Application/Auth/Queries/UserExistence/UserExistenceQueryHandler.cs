using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Auth.Queries.UserExistence;

public class UserExistenceQueryHandler: IRequestHandler<UserExistenceQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public UserExistenceQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<bool> Handle(UserExistenceQuery request, CancellationToken cancellationToken)
    {
        return await _gymifyDbContext.AspNetUsers.AnyAsync(user => user.Email == request.Email, cancellationToken);
    }
}