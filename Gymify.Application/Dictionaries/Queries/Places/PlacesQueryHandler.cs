using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dictionaries.Queries.Places;

public class PlacesQueryHandler : IRequestHandler<PlacesQuery, IEnumerable<PlaceDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public PlacesQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<IEnumerable<PlaceDTO>> Handle(PlacesQuery request, CancellationToken cancellationToken)
    {
        return await _gymifyDbContext.Places.Select(x => new PlaceDTO(x.PlaceId, x.PlaceName)).ToListAsync(cancellationToken);
    }
}