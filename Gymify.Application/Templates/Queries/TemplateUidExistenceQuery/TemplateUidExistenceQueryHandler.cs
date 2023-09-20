using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Templates.Queries.TemplateUidExistenceQuery;

public class TemplateUidExistenceQueryHandler: IRequestHandler<TemplateUidExistenceQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public TemplateUidExistenceQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public Task<bool> Handle(TemplateUidExistenceQuery request, CancellationToken cancellationToken)
    {
        return _gymifyDbContext.Templates.AnyAsync(t => t.TemplateUid == request.TemplateUid, cancellationToken);
    }
}