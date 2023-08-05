namespace Gymify.Application.Users.Queries.UsersListQuery;

public record UsersListResponse(Guid UserUid, string FirstName, string LastName, string Role, DateTime RegisterDate, string Email);