using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Templates.Commands.ShareTemplate;

public class ShareTemplateCommandHandler: IRequestHandler<ShareTemplateCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public ShareTemplateCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(ShareTemplateCommand request, CancellationToken cancellationToken)
    {
        Template template = await _gymifyDbContext.Templates.SingleOrDefaultAsync(t => t.TemplateUid == request.TemplateUid);

        template.IsShared = true;

        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}