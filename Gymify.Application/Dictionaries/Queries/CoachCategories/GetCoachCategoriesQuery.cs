using MediatR;

namespace Gymify.Application.Dictionaries.Queries.CoachCategories;

public record GetCoachCategoriesQuery(): IRequest<IEnumerable<CoachCategoryDTO>>;