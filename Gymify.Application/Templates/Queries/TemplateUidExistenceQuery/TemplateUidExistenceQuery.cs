using MediatR;

namespace Gymify.Application.Templates.Queries.TemplateUidExistenceQuery;

public record TemplateUidExistenceQuery(Guid TemplateUid): IRequest<bool>;