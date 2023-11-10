using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.GroupSessions.Commands.BookIn;

public class BookInCommandHandler : IRequestHandler<BookInCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public BookInCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(BookInCommand request, CancellationToken cancellationToken)
    {
        ClientGroupSession clientGroupSession = new ClientGroupSession
        {
            ClientGroupSessionUid = Guid.NewGuid(),
            GroupSessionUid = request.GroupSessionUid,
            ClientUid = request.UserUid
        };

        _gymifyDbContext.ClientGroupSessions.Add(clientGroupSession);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}