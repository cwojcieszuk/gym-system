using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Templates.Commands.UpdateTemplate;

public class UpdateTemplateCommandHandler : IRequestHandler<UpdateTemplateCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public UpdateTemplateCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
    {
        Template template = await _gymifyDbContext.Templates
            .Include(x => x.TemplateExercises)
            .SingleAsync(x => x.TemplateUid == request.TemplateUid, cancellationToken);

        template.TemplateName = request.TemplateName;
        template.DifficultyLevelId = request.DifficultyLevelUid;
        template.EstimatedTime = request.EstimatedTime;
        
        template.TemplateExercises.Clear();
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);
        
        List<TemplateExercise> data = request.Exercises.Select(x => new TemplateExercise()
        {
            TemplateExerciseUid = request.TemplateUid,
            ExerciseUid = x.ExerciseUid,
            TemplateUid = template.TemplateUid,
            NumberOfSets = x.NumberOfSets,
            NumberOfReps = x.NumberOfReps,
            Comments = x.Comments
        }).ToList();

        _gymifyDbContext.TemplateExercises.AddRange(data);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}