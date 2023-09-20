﻿using Gymify.Application.Templates.Commands.AddTemplate;
using MediatR;

namespace Gymify.Application.Templates.Commands.UpdateTemplate;

public record UpdateTemplateCommand(Guid TemplateUid, string TemplateName, int DifficultyLevelUid, decimal EstimatedTime, Guid UserUid, List<TemplateExerciseDTO> Exercises): IRequest<Unit>;