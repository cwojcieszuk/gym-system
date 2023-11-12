using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Profile.Queries.GetUserData;

public class GetUserDataQueryHandler : IRequestHandler<GetUserDataQuery, UserDataResponse>
{
    private readonly UserManager<AspNetUser> _userManager;
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetUserDataQueryHandler(UserManager<AspNetUser> userManager, IGymifyDbContext gymifyDbContext)
    {
        _userManager = userManager;
        _gymifyDbContext = gymifyDbContext;
    }

    public async Task<UserDataResponse> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
    {
        AspNetUser user = await _userManager.FindByIdAsync(request.UserUid.ToString());
        Coach? coach = await _gymifyDbContext.Coaches
            .Include(x => x.CoachTypes)
            .ThenInclude(x => x.CoachCategory)
            .SingleOrDefaultAsync(x => x.CoachUid == request.UserUid, cancellationToken);
        
        UserDataResponse result = new UserDataResponse(user.FirstName, user.LastName, user.Email, user.UserName, user.Birthdate, coach.Description, coach.CoachTypes.Select(x => x.CoachCategoryId) ,user.Avatar);

        return result;
    }
}