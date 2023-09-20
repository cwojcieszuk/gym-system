using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;

namespace Gymify.Application.Templates.Commands.AddTemplate;

public class AddTemplateCommandHandler: IRequestHandler<AddTemplateCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public AddTemplateCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(AddTemplateCommand request, CancellationToken cancellationToken)
    {
        Template template = new Template()
        {
            TemplateUid = Guid.NewGuid(),
            TemplateName = request.TemplateName,
            EstimatedTime = request.EstimatedTime,
            DifficultyLevelId = request.DifficultyLevelId,
            IsShared = false,
            UserUid = request.UserUid
        };

        _gymifyDbContext.Templates.Add(template);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        List<TemplateExercise> data = request.Exercises.Select(x => new TemplateExercise()
        {
            TemplateExerciseUid = Guid.NewGuid(),
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