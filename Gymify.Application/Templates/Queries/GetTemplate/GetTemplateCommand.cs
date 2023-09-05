using Gymify.Application.Templates.Responses;
using MediatR;

namespace Gymify.Application.Templates.Queries.GetTemplate;

public record GetTemplateCommand(Guid TemplateUid, Guid UserUid): IRequest<TemplateDetailsDTO>;