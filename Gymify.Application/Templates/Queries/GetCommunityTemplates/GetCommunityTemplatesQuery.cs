using Gymify.Application.Templates.Responses;
using Gymify.Shared.Wrappers;
using MediatR;

namespace Gymify.Application.Templates.Queries.GetCommunityTemplates;

public record GetCommunityTemplatesQuery(int PageNumber, int PageSize): IRequest<PagedResponse<TemplateDTO>>;