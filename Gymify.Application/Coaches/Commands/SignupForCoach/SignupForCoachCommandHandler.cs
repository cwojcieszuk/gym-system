using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Coaches.Commands.SignupForCoach;

public class SignupForCoachCommandHandler : IRequestHandler<SignupForCoachCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public SignupForCoachCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(SignupForCoachCommand request, CancellationToken cancellationToken)
    {
        CoachHour coachHour =
            await _gymifyDbContext.CoachHours.SingleAsync(x => x.CoachHourUid == request.CoachHourUid, cancellationToken);

        coachHour.ClientUid = request.UserUid;

        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}