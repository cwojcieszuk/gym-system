using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Application.Users.Commands.EditUser;

public class EditUserCommandHandler: IRequestHandler<EditUserCommand, Unit>
{
    private readonly UserManager<AspNetUser> _userManager;

    public EditUserCommandHandler(UserManager<AspNetUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        AspNetUser? user = await _userManager.FindByEmailAsync(request.Email);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.Birthdate = request.BirthDate;
        user.Gender = request.Gender;
        user.PhoneNumber = request.PhoneNumber;
        user.UserName = request.Login;

        string userRole = _userManager.GetRolesAsync(user).Result[0];
        if (userRole != request.Role)
        {
            await _userManager.RemoveFromRoleAsync(user, userRole);
            await _userManager.AddToRoleAsync(user, request.Role);
        }

        if (!String.IsNullOrWhiteSpace(request.Password) && !String.IsNullOrWhiteSpace(request.CurrentPassword))
        {
            await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.Password);
        }

        await _userManager.UpdateAsync(user);
        
        return Unit.Value;
    }
}