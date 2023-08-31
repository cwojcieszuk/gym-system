using MediatR;

namespace Gymify.Application.Dictionaries.Queries.DifficultyLevels;

public record GetDifficultyLevelsQuery() : IRequest<IEnumerable<DifficultyLevelDTO>>;
