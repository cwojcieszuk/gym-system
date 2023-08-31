using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dictionaries.Queries.DifficultyLevels;

public class DifficultyLevelQueryHandler : IRequestHandler<GetDifficultyLevelsQuery, IEnumerable<DifficultyLevelDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public DifficultyLevelQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<IEnumerable<DifficultyLevelDTO>> Handle(GetDifficultyLevelsQuery request, CancellationToken cancellationToken)
    {
        return await _gymifyDbContext.DifficultyLevels.Select(x => new DifficultyLevelDTO(x.DifficultyLevelUid, x.DifficultyLevelName)).ToListAsync(cancellationToken);
    }
}