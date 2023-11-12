using MediatR;

namespace Gymify.Application.Dictionaries.Queries.PlaceIdExistence;

public record PlaceIdExistenceQuery(int PlaceId) : IRequest<bool>;