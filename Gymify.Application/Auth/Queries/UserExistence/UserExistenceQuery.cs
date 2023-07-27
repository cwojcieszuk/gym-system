using MediatR;

namespace Gymify.Application.Auth.Queries.UserExistence;

public record UserExistenceQuery(string Email): IRequest<bool>;