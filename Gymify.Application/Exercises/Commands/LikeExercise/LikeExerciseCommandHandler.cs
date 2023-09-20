using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Exercises.Commands.LikeExercise;

public class LikeExerciseCommandHandler: IRequestHandler<LikeExerciseCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public LikeExerciseCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(LikeExerciseCommand request, CancellationToken cancellationToken)
    {
        _gymifyDbContext.FavouriteExercises.Add(new FavouriteExercise
        {
            FavouriteExerciseUid = Guid.NewGuid(), ExerciseUid = request.ExerciseUid, UserUid = request.UserUid
        });
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}