namespace Gymify.Application.Auth.Commands.Login;

public class LoginResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}