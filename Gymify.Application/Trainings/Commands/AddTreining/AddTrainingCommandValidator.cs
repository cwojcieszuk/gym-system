using FluentValidation;
using Gymify.Application.Users.Queries.UserUIdExistence;
using Gymify.Domain.Constants.Column;
using MediatR;

namespace Gymify.Application.Trainings.Commands.AddTreining;

public class AddTrainingCommandValidator : AbstractValidator<AddTrainingCommand>
{
    public AddTrainingCommandValidator(IMediator mediator)
    {
        RuleFor(x => x.UserUid)
            .MustAsync(async (x, token) => await mediator.Send(new UserUidExistenceQuery(x), token))
            .WithMessage("User doesn't exist");

        RuleFor(x => x.TrainingName)
            .MaximumLength(TrainingColumnConstants.TrainingNameLimit);
    }
}