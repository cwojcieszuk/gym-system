using Gymify.Application.Templates.Responses;
using Gymify.Shared.Wrappers;
using MediatR;

namespace Gymify.Application.Templates.Queries.GetPersonalTemplates;

public record GetPersonalTemplatesQuery(Guid UserUid, int PageNumber, int PageSize): IRequest<PagedResponse<TemplateDTO>>;