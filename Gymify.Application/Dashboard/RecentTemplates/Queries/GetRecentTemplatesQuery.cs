using MediatR;

namespace Gymify.Application.Dashboard.RecentTemplates.Queries;

public record GetRecentTemplatesQuery(Guid UserUid) : IRequest<List<RecentTemplateDTO>>;