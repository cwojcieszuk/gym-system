using MediatR;

namespace Gymify.Application.Templates.Commands.AddTemplate;

public record AddTemplateCommand(string TemplateName, int DifficultyLevelId, decimal EstimatedTime, Guid UserUid, List<TemplateExerciseDTO> Exercises): IRequest<Unit>;