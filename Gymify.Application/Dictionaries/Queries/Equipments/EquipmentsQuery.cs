using MediatR;

namespace Gymify.Application.Dictionaries.Queries.Equipments;

public record EquipmentsQuery(): IRequest<IEnumerable<EquipmentDTO>>;