using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.GroupSessions.Queries.AreSlotsAvailable;

public class AreSlotsAvailableQueryHandler : IRequestHandler<AreSlotsAvailableQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public AreSlotsAvailableQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<bool> Handle(AreSlotsAvailableQuery request, CancellationToken cancellationToken)
    {
        GroupSession groupSession = await _gymifyDbContext.GroupSessions
            .Where(x => x.GroupSessionUid == request.GroupSessionUid)
            .SingleAsync(cancellationToken);

        return groupSession.Slots == _gymifyDbContext.ClientGroupSessions.Where(x => x.GroupSessionUid == request.GroupSessionUid).Count();
    }
}