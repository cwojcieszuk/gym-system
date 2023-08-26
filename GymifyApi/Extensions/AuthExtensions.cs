using System.Security.Claims;

namespace GymifyApi.Extensions;

public static class AuthExtensions
{
    public static string GetEmail(this ClaimsPrincipal principal)
    {
        return principal.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
    }

    public static string GetUserUid(this ClaimsPrincipal principal)
    {
        return principal.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
    }
}