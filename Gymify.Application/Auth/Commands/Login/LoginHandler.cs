using System.IdentityModel.Tokens.Jwt;
using Gymify.Application.JWT;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Application.Auth.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
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
    
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
        
        if(!result.Succeeded)
        {
            return null;
        }
        
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return null;
        }
        
        
        
        var signingCredentials = _jwtHandler.GetSigningCredentials();
        var claims = _jwtHandler.GetClaims(user);
        var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        var refreshToken = _jwtHandler.GenerateRefreshToken();
        
        await _userManager.SetAuthenticationTokenAsync(
            user,
            "MyApp",
            "RefreshToken",
            refreshToken);
        
        return new LoginResponse()
        {
            AccessToken = token,
            RefreshToken = refreshToken
        };
    }
}