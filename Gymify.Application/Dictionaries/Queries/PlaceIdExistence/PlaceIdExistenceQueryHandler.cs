using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dictionaries.Queries.PlaceIdExistence;

public class PlaceIdExistenceQueryHandler : IRequestHandler<PlaceIdExistenceQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public PlaceIdExistenceQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public Task<bool> Handle(PlaceIdExistenceQuery request, CancellationToken cancellationToken)
    {
        return _gymifyDbContext.Places.AnyAsync(x => x.PlaceId == request.PlaceId, cancellationToken);
    }
}