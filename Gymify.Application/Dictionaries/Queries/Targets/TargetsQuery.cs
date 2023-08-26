using MediatR;

namespace Gymify.Application.Dictionaries.Queries.Targets;

public record TargetsQuery(): IRequest<IEnumerable<TargetDTO>>;