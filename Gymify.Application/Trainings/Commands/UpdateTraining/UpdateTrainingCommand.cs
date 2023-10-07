using MediatR;

namespace Gymify.Application.Trainings.Commands.UpdateTraining;

public record UpdateTrainingCommand(Guid TrainingUid, DateTime TrainingDate, string TrainingName, bool IsCyclical, Guid TemplateUid, Guid UserUid) : IRequest<Unit>;