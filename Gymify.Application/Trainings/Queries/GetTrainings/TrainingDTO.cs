namespace Gymify.Application.Trainings.Queries.GetTraining;

public record TrainingDTO(Guid TrainingUid, string TrainingName, DateTime TrainingDate, bool IsCyclical, decimal EstimatedTime, string TemplateName);