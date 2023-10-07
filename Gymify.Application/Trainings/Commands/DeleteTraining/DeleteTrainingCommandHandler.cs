using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Trainings.Commands.DeleteTraining;

public class DeleteTrainingCommandHandler : IRequestHandler<DeleteTrainingCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public DeleteTrainingCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }

    public async Task<Unit> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
    {
        Training training = await _gymifyDbContext.Training
            .SingleAsync(x => x.TrainingUid == request.TrainingUid, cancellationToken);
        
        UserTraining userTraining = await _gymifyDbContext.UserTrainings
            .SingleAsync(x => x.TrainingUid == training.TrainingUid, cancellationToken);
        
        _gymifyDbContext.UserTrainings.Remove(userTraining);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        _gymifyDbContext.Training.Remove(training);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        
    }
}