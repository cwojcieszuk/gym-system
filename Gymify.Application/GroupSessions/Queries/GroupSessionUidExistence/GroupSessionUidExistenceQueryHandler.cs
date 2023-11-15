using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.GroupSessions.Queries.GroupSessionUidExistence;

public class GroupSessionUidExistenceQueryHandler : IRequestHandler<GroupSessionUidExistenceQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GroupSessionUidExistenceQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public Task<bool> Handle(GroupSessionUidExistenceQuery request, CancellationToken cancellationToken)
    {
        return _gymifyDbContext.GroupSessions.AnyAsync(x => x.GroupSessionUid == request.GroupSessionUid, cancellationToken);
    }
}