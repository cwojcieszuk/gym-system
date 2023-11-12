using MediatR;

namespace Gymify.Application.Coaches.Commands.DislikeCoach;

public record DislikeCoachCommand(Guid CoachUid, Guid UserUid): IRequest<Unit>;