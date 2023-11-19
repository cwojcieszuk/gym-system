using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Coaches.Queries.GetCoachHoursByDate;

public class GetCoachHoursByDateQueryHandler : IRequestHandler<GetCoachHoursByDateQuery, IEnumerable<CoachHourDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetCoachHoursByDateQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<IEnumerable<CoachHourDTO>> Handle(GetCoachHoursByDateQuery request, CancellationToken cancellationToken)
    {
        Coach coach = await _gymifyDbContext.Coaches
            .Include(x => x.CoachHours)
            .SingleAsync(x => x.CoachUid == request.CoachUid, cancellationToken);

        return coach.CoachHours
            .Where(x => x.ClientUid == null)
            .Where(x => x.StartDate.Date == request.Date.Date)
            .Select(x => new CoachHourDTO(x.CoachHourUid, x.StartDate));
    }
}