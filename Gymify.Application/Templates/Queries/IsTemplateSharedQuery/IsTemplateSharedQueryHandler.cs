using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Templates.Queries.IsTemplateSharedQuery;

public class IsTemplateSharedQueryHandler : IRequestHandler<IsTemplateSharedQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public IsTemplateSharedQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<bool> Handle(IsTemplateSharedQuery request, CancellationToken cancellationToken)
    {
        Template template = await _gymifyDbContext.Templates.SingleOrDefaultAsync(t => t.TemplateUid == request.TemplateUid);
        
        return template.IsShared;
    }
}