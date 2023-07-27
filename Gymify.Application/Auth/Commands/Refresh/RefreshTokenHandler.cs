using System.IdentityModel.Tokens.Jwt;
using Gymify.Application.Auth.Commands.Login;
using Gymify.Application.Interfaces;
using Gymify.Application.JWT;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Auth.Commands.Refresh;

public class RefreshTokenHandler: IRequestHandler<RefreshTokenCommand, AuthResponse?>
{
    private readonly IGymifyDbContext _gymifyDbContext;
    private readonly JwtHandler _jwtHandler;
    
    public RefreshTokenHandler(IGymifyDbContext gymifyDbContext, JwtHandler jwtHandler)
    {
        _gymifyDbContext = gymifyDbContext;
        _jwtHandler = jwtHandler;
    }
    
    public async Task<AuthResponse?> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        AspNetUser? user = await _gymifyDbContext.AspNetUsers.FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken, cancellationToken);

        if (user is null || user.RefreshTokenExpiration < DateTime.UtcNow)
        {
            return null;
        }

        JwtSecurityToken tokenOptions = _jwtHandler.GenerateTokenOptions(user);
        string accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        string refreshToken = _jwtHandler.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiration = DateTime.UtcNow.AddMinutes(_jwtHandler.GetRefreshTokenExpiration());

        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}