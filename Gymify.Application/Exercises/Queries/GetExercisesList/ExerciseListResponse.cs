namespace Gymify.Application.Exercises.Queries.GetExercisesList;

public record ExerciseListResponse(Guid ExerciseUid, string ExerciseName, string GifUrl, string BodyPart, string Target, string Equipment);