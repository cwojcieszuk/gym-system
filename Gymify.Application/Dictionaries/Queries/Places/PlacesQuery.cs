using MediatR;

namespace Gymify.Application.Dictionaries.Queries.Places;

public record PlacesQuery() : IRequest<IEnumerable<PlaceDTO>>;