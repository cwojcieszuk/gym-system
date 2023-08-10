using MediatR;

namespace Gymify.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid UserUid): IRequest<Unit>;