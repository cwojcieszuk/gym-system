using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;

namespace Gymify.Application.Calendar.Commands.AddCoachHour;

public class AddCoachHourCommandHandler : IRequestHandler<AddCoachHourCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public AddCoachHourCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(AddCoachHourCommand request, CancellationToken cancellationToken)
    {
        CoachHour coachHour = new CoachHour()
        {
            CoachHourUid = Guid.NewGuid(),
            CoachUid = request.CoachUid,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };

        _gymifyDbContext.CoachHours.Add(coachHour);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}