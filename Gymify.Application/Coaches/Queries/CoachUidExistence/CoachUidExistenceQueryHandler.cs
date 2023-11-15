using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Coaches.Queries.CoachUidExistence;

public class CoachUidExistenceQueryHandler : IRequestHandler<CoachUidExistenceQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public CoachUidExistenceQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<bool> Handle(CoachUidExistenceQuery request, CancellationToken cancellationToken)
    {
        return await _gymifyDbContext.Coaches.AnyAsync(x => x.CoachUid == request.CoachUid);
    }
}