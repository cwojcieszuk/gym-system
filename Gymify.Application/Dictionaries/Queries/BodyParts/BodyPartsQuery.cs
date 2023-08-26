using MediatR;

namespace Gymify.Application.Dictionaries.Queries.BodyParts;

public record BodyPartsQuery(): IRequest<IEnumerable<BodyPartDTO>>;