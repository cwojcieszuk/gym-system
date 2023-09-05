namespace Gymify.Application.Templates.Queries.GetTemplate;

public record ExerciseDTO(Guid ExerciseUid, string ExerciseName, byte[] ExerciseGif, string BodyPart, string Target, string Equipment);