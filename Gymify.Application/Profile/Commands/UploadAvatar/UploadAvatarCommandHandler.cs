using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Profile.Commands.UploadAvatar;

public class UploadAvatarCommandHandler: IRequestHandler<UploadAvatarCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public UploadAvatarCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(UploadAvatarCommand request, CancellationToken cancellationToken)
    {
        AspNetUser user = await _gymifyDbContext.AspNetUsers.FirstOrDefaultAsync(u => u.Id == request.UserUid);

        await using var ms = new MemoryStream();
        await request.File.CopyToAsync(ms, cancellationToken);

        user.Avatar = ms.ToArray();
        
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}