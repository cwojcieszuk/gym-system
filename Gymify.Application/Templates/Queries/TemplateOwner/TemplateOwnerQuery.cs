using MediatR;

namespace Gymify.Application.Templates.Queries.TemplateOwner;

public record TemplateOwnerQuery(Guid TemplateUid, Guid UserUid): IRequest<bool>;