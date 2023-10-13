using FluentValidation;

namespace Gymify.Application.Coaches.Queries.GetCoachHoursByDate;

public class GetCoachHourByDateQueryValidator : AbstractValidator<GetCoachHoursByDateQuery>
{
    public GetCoachHourByDateQueryValidator()
    {
        RuleFor(x => x.Date)
            .Must(x => x.Date >= DateTime.Now.Date);
    }
}