using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Calendar.Queries.GetCoachHours;

public class GetCoachHoursQueryHandler : IRequestHandler<GetCoachHoursQuery, IEnumerable<CoachHourDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetCoachHoursQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<IEnumerable<CoachHourDTO>> Handle(GetCoachHoursQuery request, CancellationToken cancellationToken)
    {
        return await _gymifyDbContext.CoachHours
            .Where(x => x.CoachUid == request.CoachUid)
            .Where(x => x.StartDate.Date == request.Date.Date)
            .Include(x => x.Client)
            .ThenInclude(x => x.User)
            .Select(x => new CoachHourDTO(
                x.CoachHourUid, 
                x.CoachUid, x.ClientUid, 
                $"{x.Client.User.FirstName} {x.Client.User.LastName}",
                x.StartDate,
                x.EndDate))
            .ToListAsync(cancellationToken);
    }
}