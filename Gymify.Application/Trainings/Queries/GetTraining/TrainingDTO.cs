namespace Gymify.Application.Trainings.Queries.GetTraining;

public record TrainingDTO(Guid TrainingUid, string TrainingName, DateTime TrainingDate, decimal EstimatedTime, string TemplateName);