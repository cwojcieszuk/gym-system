using MediatR;

namespace Gymify.Application.Templates.Commands.DeleteTemplate;

public record DeleteTemplateCommand(Guid TemplateUid): IRequest<Unit>;