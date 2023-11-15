using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;

namespace Gymify.Application.GroupSessions.Commands.CreateGroupSession;

public class CreateGroupSessionCommandHandler : IRequestHandler<CreateGroupSessionCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public CreateGroupSessionCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(CreateGroupSessionCommand request, CancellationToken cancellationToken)
    {
        GroupSession groupSession = new GroupSession
        {
            GroupSessionUid = Guid.NewGuid(),
            SessionName = request.SessionName,
            Description = request.Description,
            Slots = request.Slots,
            SessionStartDate = request.SessionStartDate,
            SessionEndDate = request.SessionEndDate,
            PlaceId = request.PlaceId,
            CoachUid = request.CoachUid
        };

        _gymifyDbContext.GroupSessions.Add(groupSession);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}