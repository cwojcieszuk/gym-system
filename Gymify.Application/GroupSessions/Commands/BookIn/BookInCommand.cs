using MediatR;

namespace Gymify.Application.GroupSessions.Commands.BookIn;

public record BookInCommand(Guid UserUid, Guid GroupSessionUid) : IRequest<Unit>;