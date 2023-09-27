using Gymify.Application.Interfaces;
using Gymify.Application.Templates.Queries.GetTemplate;
using Gymify.Application.Templates.Responses;
using Gymify.Application.Trainings.Responses;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Trainings.Queries.GetTrainingDetails;

public class GetTrainingDetailsHandler : IRequestHandler<GetTrainingDetailsQuery, TrainingDetailsDTO>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetTrainingDetailsHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }

    public async Task<TrainingDetailsDTO> Handle(GetTrainingDetailsQuery request, CancellationToken cancellationToken)
    {
        Training training = await _gymifyDbContext.Training
            .Include(x => x.TrainingDate)
            .Include(x => x.TrainingName)
            .SingleAsync(x => x.TrainingUid == request.TrainingUid, cancellationToken);

        Template template = await _gymifyDbContext.Templates
            .Include(x => x.DifficultyLevel)
            .Include(x => x.TemplateExercises)
            .ThenInclude(x => x.Exercise)
            .ThenInclude(x => x.Equipment)
            .Include(x => x.TemplateExercises)
            .ThenInclude(x => x.Exercise.Target)
            .Include(x => x.TemplateExercises)
            .ThenInclude(x => x.Exercise.BodyPart)
            .SingleAsync(x => x.TemplateUid == training.TemplateUid, cancellationToken);
        
        TemplateDetailsDTO templateDetailsDto = new TemplateDetailsDTO(
            template.TemplateUid,
            template.TemplateName,
            template.DifficultyLevelId,
            template.DifficultyLevel.DifficultyLevelName,
            template.EstimatedTime,
            template.IsShared,
            template.UserUid,
            template.TemplateExercises.Select(x => new TemplateExerciseDetailsDTO(new ExerciseDTO(
                    x.ExerciseUid, x.Exercise.ExerciseName, x.Exercise.ExerciseGif, x.Exercise.BodyPart.BodyPartName, x.Exercise.Target.TargetName, x.Exercise.Equipment.EquipmentName),
                x.NumberOfSets, x.NumberOfReps, x.Comments))
        );

        return new TrainingDetailsDTO(
            training.TrainingUid,
            training.TrainingName,
            training.TrainingDate,
            templateDetailsDto);
    }
}