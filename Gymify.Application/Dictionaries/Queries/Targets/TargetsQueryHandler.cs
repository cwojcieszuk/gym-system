using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dictionaries.Queries.Targets;

public class TargetsQueryHandler: IRequestHandler<TargetsQuery, IEnumerable<TargetDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public TargetsQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<IEnumerable<TargetDTO>> Handle(TargetsQuery request, CancellationToken cancellationToken)
    {
        return await _gymifyDbContext.Targets.Select(target => new TargetDTO(target.TargetId, target.TargetName))
            .ToListAsync(cancellationToken);
    }
}