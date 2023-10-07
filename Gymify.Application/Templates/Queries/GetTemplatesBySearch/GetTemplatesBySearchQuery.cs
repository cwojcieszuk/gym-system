using Gymify.Application.Templates.Responses;
using MediatR;

namespace Gymify.Application.Templates.Queries.GetTemplatesBySearch;

public record GetTemplatesBySearchQuery(Guid UserUid, string? Search): IRequest<IEnumerable<TemplateDetailsDTO>>;