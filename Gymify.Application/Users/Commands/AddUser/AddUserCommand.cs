using MediatR;

namespace Gymify.Application.Users.Commands.AddUser;

public record AddUserCommand(string FirstName, string LastName, string Email, string Login, string Role, DateTime BirthDate, string Gender, string Password, string PhoneNumber) : IRequest<Unit>;