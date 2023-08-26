using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Exercises.Commands.DislikeExercise;

public class DislikeExerciseCommandHandler: IRequestHandler<DislikeExerciseCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public DislikeExerciseCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(DislikeExerciseCommand request, CancellationToken cancellationToken)
    {
        FavouriteExercise favouriteExercise =
            await _gymifyDbContext.FavouriteExercises.FirstOrDefaultAsync(x =>
                x.ExerciseUid == request.ExerciseUid && x.UserUid == request.UserUid);

        _gymifyDbContext.FavouriteExercises.Remove(favouriteExercise);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}