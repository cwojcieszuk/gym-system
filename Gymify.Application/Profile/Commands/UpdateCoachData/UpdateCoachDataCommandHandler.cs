using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Profile.Commands.UpdateCoachData;

public class UpdateCoachDataCommandHandler : IRequestHandler<UpdateCoachDataCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public UpdateCoachDataCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(UpdateCoachDataCommand request, CancellationToken cancellationToken)
    {
        Coach coach = await _gymifyDbContext.Coaches
            .Include(x => x.CoachTypes)
            .SingleAsync(x => x.CoachUid == request.UserUid, cancellationToken);

        coach.Description = request.Description;
        coach.CoachTypes.Clear();
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        List<CoachType> coachTypes = new();

        request.CategoryId.ForEach(x =>
        {
            coachTypes.Add(new CoachType()
            {
                CoachTypeUid = Guid.NewGuid(),
                CoachUid = coach.CoachUid,
                CoachCategoryId = x
            });
        });

        _gymifyDbContext.CoachTypes.AddRange(coachTypes);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}