using MediatR;

namespace Gymify.Application.Profile.Commands.UpdateUserData;

public record UpdateUserDataCommand(Guid UserUid, string FirstName, string Lastname, string Email, string Login, DateTime BirthDate): IRequest<Unit>;