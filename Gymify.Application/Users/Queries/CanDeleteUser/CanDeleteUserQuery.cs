using MediatR;

namespace Gymify.Application.Users.Queries.CanDeleteUser;

public record CanDeleteUserQuery(Guid UserUid): IRequest<bool>;