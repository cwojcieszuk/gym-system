using Microsoft.AspNetCore.Http;

namespace Gymify.Application.Profile.Queries.GetUserData;

public record UserDataResponse(string FirstName, string LastName, string Email, string Login, DateTime BirthDate, byte[]? Avatar = null);