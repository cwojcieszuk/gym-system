namespace Gymify.Application.Templates.Responses;

public record TemplateDTO(Guid TemplateUid, string TemplateName, decimal EstimatedTime, string DifficultyLevel, string FirstName, string LastName);