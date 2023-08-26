using MediatR;

namespace Gymify.Application.Users.Queries.UserUIdExistence;

public record UserUidExistenceQuery(Guid UserUid): IRequest<bool>;