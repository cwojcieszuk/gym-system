using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;

namespace Gymify.Application.Trainings.Commands.AddTreining;

public class AddTrainingCommandHandler : IRequestHandler<AddTrainingCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public AddTrainingCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(AddTrainingCommand request, CancellationToken cancellationToken)
    {
        Training training = new Training()
        {
            TrainingUid = Guid.NewGuid(),
            TrainingDate = request.TrainingDate,
            TrainingName = request.TrainingName,
            IsCyclical = request.IsCyclical,
            TemplateUid = request.TemplateUid
        };

        UserTraining userTraining = new UserTraining()
        {
            UserTrainingUid = Guid.NewGuid(),
            TrainingUid = training.TrainingUid,
            UserUid = request.UserUid
        };
        _gymifyDbContext.UserTrainings.Add(userTraining);
        _gymifyDbContext.Training.Add(training);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}