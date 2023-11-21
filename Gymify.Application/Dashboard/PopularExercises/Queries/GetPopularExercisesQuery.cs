using MediatR;

namespace Gymify.Application.Dashboard.PopularExercises.Queries;

public record GetPopularExercisesQuery(Guid UserUid) : IRequest<List<PopularExercisesDTO>>;