using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dictionaries.Queries.Equipments;

public class EquipmentsQueryHandler: IRequestHandler<EquipmentsQuery, IEnumerable<EquipmentDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public EquipmentsQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<IEnumerable<EquipmentDTO>> Handle(EquipmentsQuery request, CancellationToken cancellationToken)
    {
        return await _gymifyDbContext.Equipment.Select(eq => new EquipmentDTO(eq.EquipmentId, eq.EquipmentName))
            .ToListAsync(cancellationToken);
    }
}