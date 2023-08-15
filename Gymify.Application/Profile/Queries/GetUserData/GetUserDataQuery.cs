using MediatR;

namespace Gymify.Application.Profile.Queries.GetUserData;

public record GetUserDataQuery(Guid UserUid) : IRequest<UserDataResponse>;
