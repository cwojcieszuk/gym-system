using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Dictionaries.Queries.CoachCategories;

public class GetCoachCategoriesQueryHandler : IRequestHandler<GetCoachCategoriesQuery, IEnumerable<CoachCategoryDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetCoachCategoriesQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<IEnumerable<CoachCategoryDTO>> Handle(GetCoachCategoriesQuery request, CancellationToken cancellationToken)
    {
        List<CoachCategory> categories = await _gymifyDbContext.CoachCategories.ToListAsync(cancellationToken);

        return categories.Select(c => new CoachCategoryDTO(c.CoachCategoryId, c.CoachCategoryName));
    }
}