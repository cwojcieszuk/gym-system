namespace Gymify.Application.Exercises.Queries.GetExercisesList;

public record ExerciseListResponse(Guid ExerciseUid, string ExerciseName, byte[] ExerciseGif, string BodyPart, string Target, string Equipment, bool IsFavorite);