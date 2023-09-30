using MediatR;

namespace Gymify.Application.Trainings.Commands.AddTreining;

public record AddTrainingCommand(DateTime TrainingDate, string TrainingName, bool IsCyclical, Guid TemplateUid, Guid UserUid): IRequest<Unit>;