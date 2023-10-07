using Gymify.Application.Interfaces;
using Gymify.Application.Templates.Queries.GetTemplate;
using Gymify.Application.Templates.Responses;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Templates.Queries.GetTemplatesBySearch;

public class GetTemplatesBySearchQueryHandler : IRequestHandler<GetTemplatesBySearchQuery, IEnumerable<TemplateDetailsDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetTemplatesBySearchQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<IEnumerable<TemplateDetailsDTO>> Handle(GetTemplatesBySearchQuery request, CancellationToken cancellationToken)
    {
        List<Template> templates = await _gymifyDbContext.Templates
            .Where(x => x.UserUid == request.UserUid)
            .Where(x => request.Search == null || x.TemplateName.ToLower().Contains(request.Search.ToLower()))
            .Include(x => x.DifficultyLevel)
            .Include(x => x.TemplateExercises)
            .ThenInclude(x => x.Exercise)
            .ThenInclude(x => x.Equipment)
            .Include(x => x.TemplateExercises)
            .ThenInclude(x => x.Exercise.Target)
            .Include(x => x.TemplateExercises)
            .ThenInclude(x => x.Exercise.BodyPart)
            .ToListAsync(cancellationToken);
        
        return templates.Select(x => new TemplateDetailsDTO(
            x.TemplateUid,
            x.TemplateName,
            x.DifficultyLevelId,
            x.DifficultyLevel.DifficultyLevelName,
            x.EstimatedTime,
            x.IsShared,
            x.UserUid,
            x.TemplateExercises.Select(e => new TemplateExerciseDetailsDTO(new ExerciseDTO(
                    e.ExerciseUid, e.Exercise.ExerciseName, e.Exercise.ExerciseGif, e.Exercise.BodyPart.BodyPartName,
                    e.Exercise.Target.TargetName, e.Exercise.Equipment.EquipmentName),
                e.NumberOfSets, e.NumberOfReps, e.Comments))
        ));
    }
}