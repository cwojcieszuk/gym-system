using Gymify.Application.Templates.Queries.GetTemplate;
using Gymify.Domain.Entities;

namespace Gymify.Application.Templates.Responses;

public record TemplateDetailsDTO(Guid TemplateUid, string TemplateName, Guid DifficultyLevelUid, string DifficultyLevelName , decimal EstimatedTime, bool IsShared, Guid UserUid, IEnumerable<TemplateExerciseDetailsDTO> Exercises);

public record TemplateExerciseDetailsDTO(ExerciseDTO Exercise, int NumberOfSets, int NumberOfReps, string? Comments);