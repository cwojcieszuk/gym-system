using Gymify.Application.Interfaces;
using Gymify.Application.Templates.Responses;
using Gymify.Domain.Entities;
using Gymify.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Templates.Queries.GetPersonalTemplates;

public class GetPersonalTemplatesQueryHandler: IRequestHandler<GetPersonalTemplatesQuery, PagedResponse<TemplateDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetPersonalTemplatesQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<PagedResponse<TemplateDTO>> Handle(GetPersonalTemplatesQuery request, CancellationToken cancellationToken)
    {
        List<Template> templates = await _gymifyDbContext.Templates
            .Include(t => t.DifficultyLevel)
            .Include(t => t.User)
            .Where(t => !t.IsShared)
            .Where(u => u.UserUid == request.UserUid)
            .ToListAsync(cancellationToken);

        int totalRecords = templates.Count;
        int totalPages = totalRecords / request.PageSize + 1;
        
        templates = templates.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

        List<TemplateDTO> content = templates.Select(template => new TemplateDTO(
                template.TemplateUid,
                template.TemplateName,
                template.EstimatedTime,
                template.DifficultyLevel.DifficultyLevelName,
                template.User.FirstName,
                template.User.LastName
            )
        ).ToList();

        return new PagedResponse<TemplateDTO>()
        {
            Content = content,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalPages = totalPages,
            TotalRecords = totalRecords
        };
    }
}