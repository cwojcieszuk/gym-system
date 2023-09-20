using MediatR;

namespace Gymify.Application.Templates.Queries.IsTemplateSharedQuery;

public record IsTemplateSharedQuery(Guid TemplateUid): IRequest<bool>;