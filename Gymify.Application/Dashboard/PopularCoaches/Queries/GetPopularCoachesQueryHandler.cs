using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dashboard.Queries;

public class GetPopularCoachesQueryHandler : IRequestHandler<GetPopularCoachesQuery, List<PopularCoachDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetPopularCoachesQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    public async Task<List<PopularCoachDTO>> Handle(GetPopularCoachesQuery request, CancellationToken cancellationToken)
    {
        var top2 = _gymifyDbContext.FavouriteCoaches.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .Take(2)
            .Select(x => x.Key)
            .Select(c => c.CoachUid).ToList();

        var coaches = _gymifyDbContext.Coaches
            .Include(c => c.CoachTypes)
            .ThenInclude(c => c.CoachCategory)
            .Include(c => c.User)
            .Where(c => top2.Contains(c.CoachUid))
            .ToList();

        List<PopularCoachDTO> content = coaches.Select(c => new PopularCoachDTO(
            c.CoachUid,
            c.User.FirstName + " " + c.User.LastName,
            c.User.Avatar,
            c.CoachTypes.Where(x => x.CoachUid == c.CoachUid).Select(x => x.CoachCategory.CoachCategoryName),
            IsFavorite(c.CoachUid, request.UserUid)
        )).ToList();
        return content;
    }
    private bool IsFavorite(Guid coachUid, Guid userUid)
    {
        return _gymifyDbContext.FavouriteCoaches.Any(x => x.CoachUid == coachUid && x.ClientUid == userUid);
    }
}
