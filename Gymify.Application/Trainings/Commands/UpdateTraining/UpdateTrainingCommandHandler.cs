using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Trainings.Commands.UpdateTraining;

public class UpdateTrainingCommandHandler : IRequestHandler<UpdateTrainingCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public UpdateTrainingCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    public async Task<Unit> Handle(UpdateTrainingCommand request, CancellationToken cancellationToken)
    {
        Training training = await _gymifyDbContext.Training
            .SingleAsync(x => x.TrainingUid == request.TrainingUid, cancellationToken);
        
        training.TrainingDate = request.TrainingDate;
        training.TrainingName = request.TrainingName;
        training.IsCyclical = request.IsCyclical;
        training.TemplateUid = request.TemplateUid;
        
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}