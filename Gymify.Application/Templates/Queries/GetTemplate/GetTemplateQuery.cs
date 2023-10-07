using Gymify.Application.Templates.Responses;
using MediatR;

namespace Gymify.Application.Templates.Queries.GetTemplate;

public record GetTemplateQuery(Guid TemplateUid, Guid UserUid): IRequest<TemplateDetailsDTO>;