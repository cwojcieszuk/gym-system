using MediatR;

namespace Gymify.Application.Trainings.Commands.DeleteTraining;

public record DeleteTrainingCommand(Guid TrainingUid) : IRequest<Unit>;