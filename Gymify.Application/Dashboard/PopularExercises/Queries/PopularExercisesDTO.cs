namespace Gymify.Application.Dashboard.PopularExercises.Queries;

public record PopularExercisesDTO(Guid ExerciseUid, string ExerciseName, byte[] ExerciseGif, string BodyPart, bool IsFavourite);