using MediatR;

namespace Gymify.Application.Trainings.Commands.UpdateTraining;

public record UpdateTrainingCommand(Guid TrainingUid, DateTime TrainingDate, string TrainingName, Guid TemplateUid, Guid UserUid) : IRequest<Unit>;