using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using Gymify.Shared.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Users.Queries.CanDeleteUser;

public class CanDeleteUserQueryHandler: IRequestHandler<CanDeleteUserQuery, bool>
{
    private readonly UserManager<AspNetUser> _userManager;
    private readonly IGymifyDbContext _gymifyDbContext;

    public CanDeleteUserQueryHandler(UserManager<AspNetUser> userManager, IGymifyDbContext gymifyDbContext)
    {
        _userManager = userManager;
        _gymifyDbContext = gymifyDbContext;
    }

    public async Task<bool> Handle(CanDeleteUserQuery request, CancellationToken cancellationToken)
    {
        AspNetUser user = await _userManager.FindByIdAsync(request.UserUid.ToString());

        IList<string> roles = await _userManager.GetRolesAsync(user);
        string userRole = roles[0];

        bool result = userRole switch
        {
            RoleConstants.Coach => await CanDeleteCoach(user.Id),
            RoleConstants.User => await CanDeleteClient(user.Id),
            RoleConstants.Admin => false,
            _ => false
        };

        return result;
    }

    private async Task<bool> CanDeleteCoach(Guid coachUid)
    {
        Coach coach = await _gymifyDbContext.Coaches
            .Include(c => c.CoachHours)
            .Include(c => c.GroupSessions)
            .FirstAsync(c => c.CoachUid == coachUid);

        if (!(coach.GroupSessions.Any() && coach.CoachHours.Any()))
        {
            return true;
        }
        
        return coach.GroupSessions.Any(session => session.SessionStartDate.Date < DateTime.Now.Date) ||
               coach.CoachHours.Any(hour => hour.StartDate.Date < DateTime.Now.Date);
    }

    private async Task<bool> CanDeleteClient(Guid clientUid)
    {
        Client client = await _gymifyDbContext.Clients
            .Include(c => c.CoachHours)
            .Include(c => c.ClientGroupSessions).ThenInclude(c => c.GroupSession)
            .FirstAsync(c => c.ClientUid == clientUid);

        if (!(client.CoachHours.Any() && client.ClientGroupSessions.Any()))
        {
            return true;
        }

        return client.ClientGroupSessions.Any(c => c.GroupSession.SessionStartDate.Date > DateTime.Now.Date) &&
               client.CoachHours.Any(c => c.StartDate.Date > DateTime.Now.Date);
    }
}