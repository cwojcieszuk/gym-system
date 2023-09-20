using MediatR;

namespace Gymify.Application.Templates.Commands.ShareTemplate;

public record ShareTemplateCommand(Guid TemplateUid): IRequest<Unit>;