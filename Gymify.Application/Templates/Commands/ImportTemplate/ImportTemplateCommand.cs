using MediatR;

namespace Gymify.Application.Templates.Commands.ImportTemplate;

public record ImportTemplateCommand(Guid TemplateUid, Guid UserUid): IRequest<Unit>;