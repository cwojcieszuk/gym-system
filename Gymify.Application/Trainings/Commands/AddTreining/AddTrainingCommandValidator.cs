using FluentValidation;
using Gymify.Application.Users.Queries.UserUIdExistence;
using MediatR;

namespace Gymify.Application.Trainings.Commands.AddTreining;

public class AddTrainingCommandValidator : AbstractValidator<AddTrainingCommand>
{
    public AddTrainingCommandValidator(IMediator mediator)
    {
        
    }
}