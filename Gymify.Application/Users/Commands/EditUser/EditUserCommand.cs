using MediatR;

namespace Gymify.Application.Users.Commands.EditUser;

public record EditUserCommand(
    Guid UserUid,
    string FirstName, 
    string LastName, 
    string Email, 
    string Login, 
    string Role, 
    DateTime BirthDate, 
    string Gender, 
    string? Password, 
    string? CurrentPassword,
    string PhoneNumber
    ): IRequest<Unit>;