using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.GroupSessions.Queries.HasClientBookedIn;

public class HasClientBookedInQueryHandler : IRequestHandler<HasClientBookedInQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public HasClientBookedInQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public Task<bool> Handle(HasClientBookedInQuery request, CancellationToken cancellationToken)
    {
        return _gymifyDbContext.ClientGroupSessions
            .AnyAsync(x => x.GroupSessionUid == request.GroupSessionUid && x.ClientUid == request.UserUid, cancellationToken);
    }
}