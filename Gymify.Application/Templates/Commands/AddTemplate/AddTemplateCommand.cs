using MediatR;

namespace Gymify.Application.Templates.Commands.AddTemplate;

public record AddTemplateCommand(string TemplateName, Guid DifficultyLevelUid, decimal EstimatedTime, Guid UserUid, List<TemplateExerciseDTO> Exercises): IRequest<Unit>;