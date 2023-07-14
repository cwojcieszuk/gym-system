using System.IdentityModel.Tokens.Jwt;
using Gymify.Application.JWT;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Application.Auth.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, AuthResponse?>
{
    private readonly JwtHandler _jwtHandler;
    private readonly UserManager<AspNetUser> _userManager;
    private readonly SignInManager<AspNetUser> _signInManager;
    public LoginHandler(JwtHandler jwtHandler, UserManager<AspNetUser> userManager, SignInManager<AspNetUser> signInManager)
    {
        _jwtHandler = jwtHandler;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task<AuthResponse?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        SignInResult result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
        
        if(!result.Succeeded)
        {
            return null;
        }
        
        AspNetUser? user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            return null;
        }
        
        JwtSecurityToken tokenOptions = _jwtHandler.GenerateTokenOptions(user);
        string accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        string refreshToken = _jwtHandler.GenerateRefreshToken();
        
        await _userManager.SetAuthenticationTokenAsync(user, "MyApp", "RefreshToken", refreshToken);
        
        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}