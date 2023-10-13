using MediatR;

namespace Gymify.Application.Coaches.Commands.SignupForCoach;

public record SignupForCoachCommand(Guid CoachHourUid, Guid UserUid): IRequest<Unit>;