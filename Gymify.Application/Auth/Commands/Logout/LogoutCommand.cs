using MediatR;

namespace Gymify.Application.Auth.Commands.Logout;

public record LogoutCommand(string Email): IRequest<Unit>;