using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using Gymify.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Coaches.Queries.GetCoaches;

public class GetCoachesQueryHandler : IRequestHandler<GetCoachesQuery, PagedResponse<CoachDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetCoachesQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<PagedResponse<CoachDTO>> Handle(GetCoachesQuery request, CancellationToken cancellationToken)
    {
        List<Coach> coaches = await _gymifyDbContext.Coaches
            .Include(c => c.CoachTypes).ThenInclude(c => c.CoachCategory)
            .Include(c => c.FavouriteCoaches)
            .Include(c => c.User)
            .Where(x => request.Name == null || (x.User.FirstName + " " + x.User.LastName).Contains(request.Name.ToLower()))
            .Where(x => request.CategoryId == null || x.CoachTypes.Any(c => c.CoachCategoryId == request.CategoryId))
            .ToListAsync(cancellationToken);

        int totalRecords = coaches.Count;
        int totalPages = totalRecords / request.PageSize + 1;
        
        coaches = coaches.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

        List<CoachDTO> content = coaches.Select(c => new CoachDTO(
            c.CoachUid,
            c.User.FirstName + " " + c.User.LastName,
            c.User.Gender,
            c.User.Avatar,
            c.CoachTypes.Where(x => x.CoachUid == c.CoachUid).Select(x => x.CoachCategory.CoachCategoryName),
            c.Description,
            IsFavorite: IsFavorite(c.CoachUid, request.UserUid)
        )).ToList();

        return new PagedResponse<CoachDTO>()
        {
            Content = content,
            TotalRecords = totalRecords,
            TotalPages = totalPages,
            PageSize = request.PageSize,
            PageNumber = request.PageNumber
        };
    }

    private bool IsFavorite(Guid coachUid, Guid userUid)
    {
        return _gymifyDbContext.FavouriteCoaches.Any(x => x.CoachUid == coachUid && x.ClientUid == userUid);
    }
}