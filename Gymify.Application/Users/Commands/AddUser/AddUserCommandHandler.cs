using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Application.Users.Commands.AddUser;

public class AddUserCommandHandler: IRequestHandler<AddUserCommand, Unit>
{
    private readonly UserManager<AspNetUser> _userManager;
    private readonly IGymifyDbContext _gymifyDbContext;

    public AddUserCommandHandler(UserManager<AspNetUser> userManager, IGymifyDbContext gymifyDbContext)
    {
        _userManager = userManager;
        _gymifyDbContext = gymifyDbContext;
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

        switch (request.Role)
        {
            case "User":
            {
                Client client = new Client()
                {
                    ClientUid = user.Id
                };

                _gymifyDbContext.Clients.Add(client);
                await _gymifyDbContext.SaveChangesAsync(cancellationToken);
                
                break;
            }
            case "Coach":
            {
                Coach coach = new Coach()
                {
                    CoachUid = user.Id
                };

                _gymifyDbContext.Coaches.Add(coach);
                await _gymifyDbContext.SaveChangesAsync(cancellationToken);
                
                break;
            }
        }

        return Unit.Value;
    }
}