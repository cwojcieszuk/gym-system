using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Trainings.Queries.TrainingUidExistenceQuery;

public class TrainingUidExistenceQueryHandler: IRequestHandler<TrainingUidExistenceQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public TrainingUidExistenceQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public Task<bool> Handle(TrainingUidExistenceQuery request, CancellationToken cancellationToken)
    {
        return _gymifyDbContext.Training.AnyAsync(t => t.TrainingUid == request.TrainingUid, cancellationToken);
    }
}