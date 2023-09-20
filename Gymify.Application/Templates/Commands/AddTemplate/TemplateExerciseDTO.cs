namespace Gymify.Application.Templates.Commands.AddTemplate;

public record TemplateExerciseDTO(Guid ExerciseUid, int NumberOfSets, int NumberOfReps, string? Comments);