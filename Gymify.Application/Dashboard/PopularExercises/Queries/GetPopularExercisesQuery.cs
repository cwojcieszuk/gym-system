using MediatR;

namespace Gymify.Application.Dashboard.PopularExercises.Queries;

public record GetPopularExercisesQuery(Guid UserUid, int Amount) : IRequest<List<PopularExercisesDTO>>;