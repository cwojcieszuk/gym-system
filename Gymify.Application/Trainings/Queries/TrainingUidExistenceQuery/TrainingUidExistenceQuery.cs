using MediatR;

namespace Gymify.Application.Trainings.Queries.TrainingUidExistenceQuery;

public record TrainingUidExistenceQuery(Guid TrainingUid): IRequest<bool>;