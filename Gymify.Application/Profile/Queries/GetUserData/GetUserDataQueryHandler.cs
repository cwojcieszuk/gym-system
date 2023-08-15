using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Application.Profile.Queries.GetUserData;

public class GetUserDataQueryHandler : IRequestHandler<GetUserDataQuery, UserDataResponse>
{
    private readonly UserManager<AspNetUser> _userManager;

    public GetUserDataQueryHandler(UserManager<AspNetUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserDataResponse> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
    {
        AspNetUser user = await _userManager.FindByIdAsync(request.UserUid.ToString());

        UserDataResponse result = new UserDataResponse(user.FirstName, user.LastName, user.Email, user.UserName, user.Birthdate);

        return result;
    }
}