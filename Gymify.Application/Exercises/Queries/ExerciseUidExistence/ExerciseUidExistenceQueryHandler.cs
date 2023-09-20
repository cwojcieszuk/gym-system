using Gymify.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Exercises.Queries.ExerciseUidExistence;

public class ExerciseUidExistenceQueryHandler: IRequestHandler<ExerciseUidExistenceQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;
    
    public ExerciseUidExistenceQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<bool> Handle(ExerciseUidExistenceQuery request, CancellationToken cancellationToken)
    {
        return await _gymifyDbContext.Exercises.AnyAsync(ex => ex.ExerciseUid == request.ExerciseUid);
    }
}