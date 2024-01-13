using Gymify.Application.Dashboard.IncomingTrainings.Queries;
using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dashboard.RecentTemplates.Queries;

public class GetRecentTemplateQueryHandler : IRequestHandler<GetRecentTemplatesQuery, List<RecentTemplateDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetRecentTemplateQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    public async Task<List<RecentTemplateDTO>> Handle(GetRecentTemplatesQuery request, CancellationToken cancellationToken)
    {
        List<Template> templates = await _gymifyDbContext.Templates
            .Include(t => t.DifficultyLevel)
            .Include(t => t.User)
            .Where(t => t.IsShared)
            .ToListAsync(cancellationToken);
        
        IEnumerable<Template> recentTemplates = templates.Skip(Math.Max(0, templates.Count() - 3));
        
        List<RecentTemplateDTO> content = recentTemplates.Select(r => new RecentTemplateDTO(
            r.TemplateUid,
            r.TemplateName,
            r.DifficultyLevel.DifficultyLevelName,
            r.User.FirstName + " " + r.User.LastName)).ToList();
        
        return content;
    }
}