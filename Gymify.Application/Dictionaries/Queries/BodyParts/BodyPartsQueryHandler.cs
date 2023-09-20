using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dictionaries.Queries.BodyParts;

public class BodyPartsQueryHandler: IRequestHandler<BodyPartsQuery, IEnumerable<BodyPartDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public BodyPartsQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<IEnumerable<BodyPartDTO>> Handle(BodyPartsQuery request, CancellationToken cancellationToken)
    {
        return await _gymifyDbContext.BodyParts
            .Select(bodyPart => new BodyPartDTO(bodyPart.BodyPartId, bodyPart.BodyPartName)).ToListAsync(cancellationToken);
    }
}