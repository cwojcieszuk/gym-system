using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dashboard.IncomingTrainings.Queries;

public class GetIncomingGroupSessionsQueryHandler : IRequestHandler<GetIncomingGroupSessionsQuery, List<IncomingGroupSessionDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetIncomingGroupSessionsQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }

    public async Task<List<IncomingGroupSessionDTO>> Handle(GetIncomingGroupSessionsQuery request,
        CancellationToken cancellationToken)
    {
        List<GroupSession> groupSessionsList = await _gymifyDbContext.GroupSessions
            .Include(x => x.Coach)
            .ThenInclude(x => x.User)
            .Include(x => x.Place)
            .OrderBy(x => x.SessionStartDate.Day)
            .ThenBy(x => x.SessionStartDate.Hour)
            .Take(request.Amount)
            .ToListAsync(cancellationToken);
        
        List<IncomingGroupSessionDTO> content = groupSessionsList.Select(g => new IncomingGroupSessionDTO(
            g.GroupSessionUid,
            g.SessionName,
            g.Coach.User.FirstName + " " + g.Coach.User.LastName,
            g.Place.PlaceName,
            g.SessionStartDate)).ToList();
        
        return content;
    } 
}