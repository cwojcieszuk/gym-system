using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Coaches.Queries.CoachHourUidExistence;

public class CoachHourUidExistenceQueryHandler : IRequestHandler<CoachHourUidExistenceQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public CoachHourUidExistenceQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<bool> Handle(CoachHourUidExistenceQuery request, CancellationToken cancellationToken)
    {
        return await _gymifyDbContext.CoachHours.AnyAsync(x => x.CoachHourUid == request.CoachHourUid, cancellationToken);
    }
}