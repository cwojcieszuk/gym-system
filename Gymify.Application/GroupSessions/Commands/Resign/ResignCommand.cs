using MediatR;

namespace Gymify.Application.GroupSessions.Commands.Resign;

public record ResignCommand(Guid UserUid, Guid GroupSessionUid) : IRequest<Unit>;