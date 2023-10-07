using MediatR;

namespace Gymify.Application.Coaches.Commands.LikeCoach;

public record LikeCoachCommand(Guid UserUid, Guid CoachUid): IRequest<Unit>;