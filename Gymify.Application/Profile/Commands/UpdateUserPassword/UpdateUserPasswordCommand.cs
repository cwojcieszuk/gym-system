using MediatR;

namespace Gymify.Application.Profile.Commands.UpdateUserPassword;

public record UpdateUserPasswordCommand(Guid UserUid, string Password, string NewPassword, string ConfirmPassword): IRequest<Unit>;