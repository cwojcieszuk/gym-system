using MediatR;

namespace Gymify.Application.Auth.Queries.UserPassword;

public record UserPasswordQuery(string Email, string Password): IRequest<bool>;