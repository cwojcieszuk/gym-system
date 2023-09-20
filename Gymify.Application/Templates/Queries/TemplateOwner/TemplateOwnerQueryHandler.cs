using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Templates.Queries.TemplateOwner;

public class TemplateOwnerQueryHandler: IRequestHandler<TemplateOwnerQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public TemplateOwnerQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<bool> Handle(TemplateOwnerQuery request, CancellationToken cancellationToken)
    {
        Template template = await _gymifyDbContext.Templates.SingleAsync(x => x.TemplateUid == request.TemplateUid, cancellationToken);

        return template.UserUid == request.UserUid;
    }
}