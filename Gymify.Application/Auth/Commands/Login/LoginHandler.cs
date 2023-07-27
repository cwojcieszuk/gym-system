using System.IdentityModel.Tokens.Jwt;
using Gymify.Application.JWT;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Application.Auth.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, AuthResponse>
{
    private readonly JwtHandler _jwtHandler;
    private readonly UserManager<AspNetUser> _userManager;
    public LoginHandler(JwtHandler jwtHandler, UserManager<AspNetUser> userManager)
    {
        _jwtHandler = jwtHandler;
        _userManager = userManager;
    }
    
    public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AspNetUser user = await _userManager.FindByEmailAsync(request.Email);

        JwtSecurityToken tokenOptions = _jwtHandler.GenerateTokenOptions(user);
        string accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        string refreshToken = _jwtHandler.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiration = DateTime.UtcNow.AddMinutes(_jwtHandler.GetRefreshTokenExpiration());

        await _userManager.UpdateAsync(user);
        await _userManager.SetAuthenticationTokenAsync(user, "MyApp", "RefreshToken", refreshToken);
        
        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}