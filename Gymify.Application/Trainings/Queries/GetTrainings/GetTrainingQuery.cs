using Gymify.Shared.Wrappers;
using MediatR;

namespace Gymify.Application.Trainings.Queries.GetTraining;

public record GetTrainingQuery(Guid UserUid, int PageNumber, int PageSize) : IRequest<PagedResponse<TrainingDTO>>;