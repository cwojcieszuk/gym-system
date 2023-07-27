using Gymify.Application.Auth.Commands.Login;
using MediatR;

namespace Gymify.Application.Auth.Commands.Refresh;

public record RefreshTokenCommand(string RefreshToken): IRequest<AuthResponse>;