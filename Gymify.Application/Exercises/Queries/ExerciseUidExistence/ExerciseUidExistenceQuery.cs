using MediatR;

namespace Gymify.Application.Exercises.Queries.ExerciseUidExistence;

public record ExerciseUidExistenceQuery(Guid ExerciseUid): IRequest<bool>;