using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Coaches.Commands.DislikeCoach;

public class DislikeCoachCommandHandler : IRequestHandler<DislikeCoachCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public DislikeCoachCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(DislikeCoachCommand request, CancellationToken cancellationToken)
    {
        FavouriteCoach favouriteCoach = await _gymifyDbContext.FavouriteCoaches
            .SingleAsync(x => x.CoachUid == request.CoachUid && x.ClientUid == request.UserUid, cancellationToken);

        _gymifyDbContext.FavouriteCoaches.Remove(favouriteCoach);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}