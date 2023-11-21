using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dashboard.PopularExercises.Queries;

public class GetPopularExercisesQueryHandler : IRequestHandler<GetPopularExercisesQuery, List<PopularExercisesDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetPopularExercisesQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }

    public async Task<List<PopularExercisesDTO>> Handle(GetPopularExercisesQuery request,
        CancellationToken cancellationToken)
    {
        var top2 = _gymifyDbContext.FavouriteExercises.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .Take(2)
            .Select(x => x.Key)
            .Select(c => c.ExerciseUid).ToList();
        var exercises = _gymifyDbContext.Exercises
            .Include(e => e.BodyPart)
            .Include(e => e.Equipment)
            .Include(e => e.Target)
            .Where(c => top2.Contains(c.ExerciseUid))
            .ToList();

        List<PopularExercisesDTO> content = exercises.Select(c => new PopularExercisesDTO(
            c.ExerciseUid,
            c.ExerciseName,
            c.ExerciseGif,
            c.BodyPart.BodyPartName,
            IsFavorite(c.ExerciseUid, request.UserUid)
        )).ToList();
        return content;
    }
    private bool IsFavorite(Guid exerciseUid, Guid userUid)
    {
        return _gymifyDbContext.FavouriteExercises.Any(x => x.ExerciseUid == exerciseUid && x.UserUid == userUid);
    }
}