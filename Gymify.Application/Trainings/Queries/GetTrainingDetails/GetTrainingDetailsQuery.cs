using Gymify.Application.Trainings.Responses;
using MediatR;

namespace Gymify.Application.Trainings.Queries.GetTrainingDetails;

public record GetTrainingDetailsQuery(Guid TrainingUid, Guid UserUid) : IRequest<TrainingDetailsDTO>;