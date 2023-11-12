using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using Gymify.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.GroupSessions.Queries.GetGroupSessions;

public class GetGroupSessionsQueryHandler : IRequestHandler<GetGroupSessionsQuery, PagedResponse<GroupSessionDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetGroupSessionsQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<PagedResponse<GroupSessionDTO>> Handle(GetGroupSessionsQuery request, CancellationToken cancellationToken)
    {
        List<GroupSession> groupSessions = await _gymifyDbContext.GroupSessions
            .Include(x => x.Coach)
            .ThenInclude(x => x.CoachTypes)
            .Include(x => x.Coach)
            .ThenInclude(x => x.User)
            .Include(x => x.Place)
            .Include(x => x.ClientGroupSessions)
            .Where(x => x.SessionStartDate.Date == request.Date.Date)
            .Where(x => request.Name == null || x.SessionName == request.Name)
            .Where(x => request.CategoryId == null ||
                        x.Coach.CoachTypes.Any(c => c.CoachCategoryId == request.CategoryId))
            .Where(x => request.CoachUid == null || x.CoachUid == request.CoachUid)
            .ToListAsync(cancellationToken);

        int totalRecords = groupSessions.Count;
        int totalPages = totalRecords / request.PageSize + 1;

        groupSessions = groupSessions.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

        List<GroupSessionDTO> content = groupSessions.Select(x => new GroupSessionDTO()
        {
            GroupSessionUid = x.GroupSessionUid,
            GroupSessionName = x.SessionName,
            Hour = $"{x.SessionStartDate.Hour}:{x.SessionStartDate.Minute}",
            Place = $"{x.Place.PlaceName}",
            CoachName = $"{x.Coach.User.FirstName} {x.Coach.User.LastName}",
            Duration = CountDuration((x.SessionEndDate - x.SessionStartDate).TotalHours),
            AvailableSlots = x.Slots,
            TakenSlots = x.ClientGroupSessions.Where(g => g.GroupSessionUid == x.GroupSessionUid).Count(),
            Description = x.Description,
            IsBookedIn = IsBookedIn(x.GroupSessionUid, request.UserUid)
        }).ToList();

        return new PagedResponse<GroupSessionDTO>()
        {
            Content = content,
            TotalRecords = totalRecords,
            TotalPages = totalPages,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }

    private bool IsBookedIn(Guid groupSessionUid, Guid userUid)
    {
        return _gymifyDbContext.ClientGroupSessions.Any(x => x.GroupSessionUid == groupSessionUid && x.ClientUid == userUid);
    }

    private string CountDuration(double totalHours)
    {
        switch (totalHours)
        {
            case < 1.0:
                return $"{totalHours * 60} minutes";
            case 1.0:
                return $"{totalHours} hour";
            default:
                return $"{totalHours} hours";
        }
    }
}