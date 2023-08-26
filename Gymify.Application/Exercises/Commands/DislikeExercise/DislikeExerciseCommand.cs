using MediatR;

namespace Gymify.Application.Exercises.Commands.DislikeExercise;

public record DislikeExerciseCommand(Guid ExerciseUid, Guid UserUid): IRequest<Unit>;