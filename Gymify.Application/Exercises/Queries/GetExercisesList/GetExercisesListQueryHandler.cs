using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using Gymify.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Exercises.Queries.GetExercisesList;

public class GetExercisesListQueryHandler : IRequestHandler<GetExercisesListQuery, PagedResponse<ExerciseListResponse>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetExercisesListQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<PagedResponse<ExerciseListResponse>> Handle(GetExercisesListQuery request, CancellationToken cancellationToken)
    {
        List<Exercise> exercises = await _gymifyDbContext.Exercises
            .Include(ex => ex.BodyPart)
            .Include(ex => ex.Equipment)
            .Include(ex => ex.Target)
            .Where(ex => request.EquipmentId == null || ex.EquipmentId == request.EquipmentId)
            .Where(ex => request.BodyPartId == null || ex.BodyPartId == request.BodyPartId)
            .Where(ex => request.TargetId == null || ex.TargetId == request.TargetId)
            .Where(ex => request.Name == null || ex.ExerciseName.ToLower().Contains(request.Name.ToLower()))
            .Where(ex => request.ShowFavorite == false || (request.ShowFavorite == true && _gymifyDbContext.FavouriteExercises.Any(x => x.ExerciseUid == ex.ExerciseUid && x.UserUid == request.UserUid)))
            .ToListAsync(cancellationToken);

        int totalRecords = exercises.Count;
        int totalPages = totalRecords / request.PageSize + 1;

        exercises = exercises.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

        List<ExerciseListResponse> result = exercises.Select(ex => new ExerciseListResponse(
            ex.ExerciseUid, 
            ex.ExerciseName, 
            ex.ExerciseGif,
            ex.BodyPart.BodyPartName,
            ex.Target.TargetName,
            ex.Equipment.EquipmentName,
            IsFavorite: IsFavorite(ex.ExerciseUid, request.UserUid)
            )).ToList();

        return new PagedResponse<ExerciseListResponse>()
        {
            Content = result,
            TotalRecords = totalRecords,
            TotalPages = totalPages,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }

    private bool IsFavorite(Guid exerciseUid, Guid userUid)
    {
        return _gymifyDbContext.FavouriteExercises.Any(x => x.ExerciseUid == exerciseUid && x.UserUid == userUid);
    }
}