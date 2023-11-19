using FluentValidation;

namespace Gymify.Application.Calendar.Commands.AddCoachHour;

public class AddCoachHourCommandValidator : AbstractValidator<AddCoachHourCommand>
{
    public AddCoachHourCommandValidator()
    {
        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate);
    }
}