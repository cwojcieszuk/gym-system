namespace Gymify.Application.Users.Queries.UsersListQuery;

public record UsersListResponse(
    Guid UserUid, 
    string FirstName, 
    string LastName, 
    string Role, 
    DateTime BirthDate, 
    string Email,
    string Gender,
    string PhoneNumber,
    string Login,
    bool CanDelete
    );