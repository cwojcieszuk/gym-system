using Gymify.Application.Templates.Responses;

namespace Gymify.Application.Trainings.Responses;

public record TrainingDetailsDTO(Guid TrainingUid, string TrainingName, DateTime TrainingDate, TemplateDetailsDTO TemplateDetailsDTO);