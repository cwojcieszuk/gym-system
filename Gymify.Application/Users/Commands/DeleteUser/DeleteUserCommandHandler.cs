using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using Gymify.Shared.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly UserManager<AspNetUser> _userManager;
    private readonly IGymifyDbContext _gymifyDbContext;

    public DeleteUserCommandHandler(UserManager<AspNetUser> userManager, IGymifyDbContext gymifyDbContext)
    {
        _userManager = userManager;
        _gymifyDbContext = gymifyDbContext;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        AspNetUser user = await _userManager.Users
            .Include(u => u.FavouriteExercises)
            .Include(u => u.UserTrainings)
            .FirstAsync(u => u.Id == request.UserUid, cancellationToken);

        IList<string> roles = await _userManager.GetRolesAsync(user);
        string userRole = roles[0];

        switch (userRole)
        {
            case RoleConstants.Coach:
            {
                await DeleteCoach(user.Id, cancellationToken);
                break;
            }
            case RoleConstants.User:
            {
                await DeleteClient(user.Id, cancellationToken);
                break;
            }
        }
        
        _gymifyDbContext.UserTrainings.RemoveRange(user.UserTrainings);
        _gymifyDbContext.FavouriteExercises.RemoveRange(user.FavouriteExercises);
        
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);
        await _userManager.DeleteAsync(user);

        return Unit.Value;
    }

    private async Task DeleteCoach(Guid coachUid, CancellationToken cancellationToken)
    {
        Coach coach = await _gymifyDbContext.Coaches
            .Include(c => c.GroupSessions)
            .Include(c => c.CoachTypes)
            .Include(c => c.CoachHours)
            .Include(c => c.FavouriteCoaches)
            .FirstAsync(c => c.CoachUid == coachUid, cancellationToken);
        
        _gymifyDbContext.GroupSessions.RemoveRange(coach.GroupSessions);
        _gymifyDbContext.CoachTypes.RemoveRange(coach.CoachTypes);
        _gymifyDbContext.CoachHours.RemoveRange(coach.CoachHours);
        _gymifyDbContext.FavouriteCoaches.RemoveRange(coach.FavouriteCoaches);
        _gymifyDbContext.Coaches.Remove(coach);
        
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task DeleteClient(Guid clientUid, CancellationToken cancellationToken)
    {
        Client client = await _gymifyDbContext.Clients
            .Include(c => c.CoachHours)
            .Include(c => c.FavouriteCoaches)
            .Include(c => c.ClientGroupSessions)
            .FirstAsync(c => c.ClientUid == clientUid, cancellationToken);
        
        _gymifyDbContext.ClientGroupSessions.RemoveRange(client.ClientGroupSessions);
        _gymifyDbContext.CoachHours.RemoveRange(client.CoachHours);
        _gymifyDbContext.FavouriteCoaches.RemoveRange(client.FavouriteCoaches);
        _gymifyDbContext.Clients.Remove(client);

        await _gymifyDbContext.SaveChangesAsync(cancellationToken);
    }
}