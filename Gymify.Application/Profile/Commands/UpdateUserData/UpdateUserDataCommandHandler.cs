using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Application.Profile.Commands.UpdateUserData;

public class UpdateUserDataCommandHandler: IRequestHandler<UpdateUserDataCommand, Unit>
{
    private readonly UserManager<AspNetUser> _userManager;

    public UpdateUserDataCommandHandler(UserManager<AspNetUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<Unit> Handle(UpdateUserDataCommand request, CancellationToken cancellationToken)
    {
        AspNetUser user = await _userManager.FindByIdAsync(request.UserUid.ToString());

        user.FirstName = request.FirstName;
        user.LastName = request.Lastname;
        user.UserName = request.Login;
        user.Email = request.Email;
        user.Birthdate = request.BirthDate;

        await _userManager.UpdateAsync(user);
        
        return Unit.Value;
    }
}