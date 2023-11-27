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
        List<Guid> top3 = await _gymifyDbContext.FavouriteCoaches.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .Take(request.Amount)
            .Select(x => x.Key.CoachUid).ToListAsync(cancellationToken);

        List<Coach> coaches = await _gymifyDbContext.Coaches
            .Include(c => c.CoachTypes)
            .ThenInclude(c => c.CoachCategory)
            .Include(c => c.User)
            .Where(c => top3.Contains(c.CoachUid))
            .ToListAsync(cancellationToken);

        List<PopularCoachDTO> content = coaches.Select(c => new PopularCoachDTO(
            c.CoachUid,
            $"{c.User.FirstName} {c.User.LastName}",
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
