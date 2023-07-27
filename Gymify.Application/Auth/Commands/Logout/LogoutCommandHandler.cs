using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Auth.Commands.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public LogoutCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        AspNetUser user = await _gymifyDbContext.AspNetUsers.FirstOrDefaultAsync(u => u.Email == request.Email);

        user.RefreshToken = null;
        user.RefreshTokenExpiration = null;

        await _gymifyDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}