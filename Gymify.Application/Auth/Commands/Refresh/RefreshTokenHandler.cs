using System.IdentityModel.Tokens.Jwt;
using Gymify.Application.Auth.Commands.Login;
using Gymify.Application.JWT;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Application.Auth.Commands.Refresh;

public class RefreshTokenHandler: IRequestHandler<RefreshTokenCommand, AuthResponse?>
{
    private readonly UserManager<AspNetUser> _userManager;
    private readonly JwtHandler _jwtHandler;
    
    public RefreshTokenHandler(UserManager<AspNetUser> userManager, JwtHandler jwtHandler)
    {
        _userManager = userManager;
        _jwtHandler = jwtHandler;
    }
    
    public async Task<AuthResponse?> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        AspNetUser? user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            return null;
        }
        
        bool isValid = await _userManager.VerifyUserTokenAsync(user, "MyApp", "RefreshToken", request.RefreshToken);

        if (!isValid)
        {
            return null;
        }
        
        JwtSecurityToken tokenOptions = _jwtHandler.GenerateTokenOptions(user);
        string accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        string refreshToken = _jwtHandler.GenerateRefreshToken();

        return new AuthResponse()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}