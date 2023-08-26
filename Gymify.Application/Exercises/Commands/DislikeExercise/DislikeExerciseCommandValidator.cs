using FluentValidation;
using Gymify.Application.Exercises.Queries.ExerciseUidExistence;
using Gymify.Application.Users.Queries.UserUIdExistence;
using MediatR;

namespace Gymify.Application.Exercises.Commands.DislikeExercise;

public class DislikeExerciseCommandValidator: AbstractValidator<DislikeExerciseCommand>
{
    public DislikeExerciseCommandValidator(IMediator mediator)
    {
        RuleFor(x => x.ExerciseUid)
            .MustAsync(async (x, token) => await mediator.Send(new ExerciseUidExistenceQuery(x), token));
        
        RuleFor(x => x.UserUid)
            .MustAsync(async (x, token) => await mediator.Send(new UserUidExistenceQuery(x), token));
    }
}