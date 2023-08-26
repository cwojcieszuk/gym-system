using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Application.Profile.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand, Unit>
{
    private readonly UserManager<AspNetUser> _userManager;

    public UpdateUserPasswordCommandHandler(UserManager<AspNetUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        AspNetUser user = await _userManager.FindByIdAsync(request.UserUid.ToString());

        await _userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);

        return Unit.Value;
    }
}