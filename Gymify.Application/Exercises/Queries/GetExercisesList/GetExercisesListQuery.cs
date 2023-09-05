using Gymify.Shared.Wrappers;
using MediatR;

namespace Gymify.Application.Exercises.Queries.GetExercisesList;

public record GetExercisesListQuery(Guid UserUid, int PageSize, int PageNumber, int? BodyPartId, int? EquipmentId, int? TargetId, string? Name, bool ShowFavorite = false): IRequest<PagedResponse<ExerciseListResponse>>;