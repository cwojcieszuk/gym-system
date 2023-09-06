using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Templates.Commands.ImportTemplate;

public class ImportTemplateCommandHandler: IRequestHandler<ImportTemplateCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public ImportTemplateCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(ImportTemplateCommand request, CancellationToken cancellationToken)
    {
        Template template = await _gymifyDbContext.Templates
            .Include(x => x.TemplateExercises)
            .SingleAsync(x => x.TemplateUid == request.TemplateUid, cancellationToken);

        Template newTemplate = new Template
        {
            TemplateUid = Guid.NewGuid(),
            UserUid = request.UserUid,
            TemplateName = template.TemplateName,
            EstimatedTime = template.EstimatedTime,
            DifficultyLevelUid = template.DifficultyLevelUid,
            IsShared = false
        };

        _gymifyDbContext.Templates.Add(newTemplate);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        List<TemplateExercise> templateExercises = template.TemplateExercises.Select(x => new TemplateExercise
        {
            TemplateExerciseUid = Guid.NewGuid(),
            TemplateUid = newTemplate.TemplateUid,
            ExerciseUid = x.ExerciseUid,
            NumberOfSets = x.NumberOfSets,
            NumberOfReps = x.NumberOfReps,
            Comments = x.Comments
        }).ToList();
        
        _gymifyDbContext.TemplateExercises.AddRange(templateExercises);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}