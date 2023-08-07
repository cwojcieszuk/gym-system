using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Application.Users.Commands.AddUser;

public class AddUserCommandHandler: IRequestHandler<AddUserCommand, Unit>
{
    private readonly UserManager<AspNetUser> _userManager;

    public AddUserCommandHandler(UserManager<AspNetUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        AspNetUser user = new AspNetUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.Login,
            Birthdate = request.BirthDate,
            Gender = request.Gender,
            PhoneNumber = request.PhoneNumber,
            CreatedAt = DateTime.Now
        };

        await _userManager.CreateAsync(user, request.Password);
        await _userManager.AddToRoleAsync(user, request.Role);
        
        return Unit.Value;
    }
}