using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;

namespace Gymify.Application.Coaches.Commands.LikeCoach;

public class LikeCoachCommandHandler : IRequestHandler<LikeCoachCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public LikeCoachCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(LikeCoachCommand request, CancellationToken cancellationToken)
    {
        FavouriteCoach favouriteCoach = new FavouriteCoach()
        {
            FavouriteCoachUid = Guid.NewGuid(),
            ClientUid = request.UserUid,
            CoachUid = request.CoachUid
        };

        _gymifyDbContext.FavouriteCoaches.Add(favouriteCoach);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}