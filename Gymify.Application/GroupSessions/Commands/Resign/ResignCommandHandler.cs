using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.GroupSessions.Commands.Resign;

public class ResignCommandHandler : IRequestHandler<ResignCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public ResignCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(ResignCommand request, CancellationToken cancellationToken)
    {
        ClientGroupSession clientGroupSession = await _gymifyDbContext.ClientGroupSessions
            .SingleAsync(x => x.GroupSessionUid == request.GroupSessionUid && x.ClientUid == request.UserUid, cancellationToken);

        _gymifyDbContext.ClientGroupSessions.Remove(clientGroupSession);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}