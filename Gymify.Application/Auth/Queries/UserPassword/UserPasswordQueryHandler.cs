using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Application.Auth.Queries.UserPassword;

public class UserPasswordQueryHandler: IRequestHandler<UserPasswordQuery, bool>
{
    private readonly SignInManager<AspNetUser> _signInManager;

    public UserPasswordQueryHandler(SignInManager<AspNetUser> signInManager)
    {
        _signInManager = signInManager;
    }
    
    public async Task<bool> Handle(UserPasswordQuery request, CancellationToken cancellationToken)
    {
        string username = request.Email.Substring(0, request.Email.IndexOf("@"));
        
        SignInResult result = await _signInManager.PasswordSignInAsync(username, request.Password, false, false);
        
        return result.Succeeded;
    }
}