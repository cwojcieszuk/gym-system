using MediatR;

namespace Gymify.Application.Exercises.Commands.LikeExercise;

public record LikeExerciseCommand(Guid UserUid, Guid ExerciseUid): IRequest<Unit>;