using System.IdentityModel.Tokens.Jwt;
using Gymify.Application.Auth.Commands.Login;
using Gymify.Application.JWT;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Auth.Commands.Refresh;

public class RefreshTokenHandler: IRequestHandler<RefreshTokenCommand, AuthResponse?>
{
    private readonly JwtHandler _jwtHandler;
    private readonly UserManager<AspNetUser> _userManager;
    
    public RefreshTokenHandler(JwtHandler jwtHandler, UserManager<AspNetUser> userManager)
    {
        _jwtHandler = jwtHandler;
        _userManager = userManager;
    }
    
    public async Task<AuthResponse?> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        
        AspNetUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken, cancellationToken);

        if (user is null || user.RefreshTokenExpiration < DateTime.UtcNow)
        {
            return null;
        }

        JwtSecurityToken tokenOptions = await _jwtHandler.GenerateTokenOptions(user);
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