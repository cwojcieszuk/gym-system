using MediatR;

namespace Gymify.Application.Trainings.Commands.AddTreining;

public record AddTrainingCommand(DateTime TrainingDate, string TrainingName, Guid TemplateUid, Guid UserUid): IRequest<Unit>;