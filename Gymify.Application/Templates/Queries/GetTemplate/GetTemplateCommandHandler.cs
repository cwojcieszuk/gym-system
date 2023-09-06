using Gymify.Application.Interfaces;
using Gymify.Application.Templates.Commands.AddTemplate;
using Gymify.Application.Templates.Responses;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Templates.Queries.GetTemplate;

public class GetTemplateCommandHandler: IRequestHandler<GetTemplateCommand, TemplateDetailsDTO>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetTemplateCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<TemplateDetailsDTO> Handle(GetTemplateCommand request, CancellationToken cancellationToken)
    {
        Template template = await _gymifyDbContext.Templates
            .Include(x => x.DifficultyLevel)
            .Include(x => x.TemplateExercises)
            .ThenInclude(x => x.Exercise)
            .ThenInclude(x => x.Equipment)
            .Include(x => x.TemplateExercises)
            .ThenInclude(x => x.Exercise.Target)
            .Include(x => x.TemplateExercises)
            .ThenInclude(x => x.Exercise.BodyPart)
            .SingleAsync(x => x.TemplateUid == request.TemplateUid, cancellationToken);

        return new TemplateDetailsDTO(
            template.TemplateUid,
            template.TemplateName,
            template.DifficultyLevelUid,
            template.DifficultyLevel.DifficultyLevelName,
            template.EstimatedTime,
            template.IsShared,
            template.UserUid,
            template.TemplateExercises.Select(x => new TemplateExerciseDetailsDTO(new ExerciseDTO(
                x.ExerciseUid, x.Exercise.ExerciseName, x.Exercise.ExerciseGif, x.Exercise.BodyPart.BodyPartName, x.Exercise.Target.TargetName, x.Exercise.Equipment.EquipmentName),
                x.NumberOfSets, x.NumberOfReps, x.Comments))
            );
    }
}