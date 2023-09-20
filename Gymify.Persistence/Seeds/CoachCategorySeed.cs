using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Seeds;

public static class CoachCategorySeed
{
    public static void Seed(this EntityTypeBuilder<CoachCategory> modelBuilder)
    {
        List<CoachCategory> coachCategories = new()
        {
            new()
            {
                CoachCategoryId    = 0,
                CoachCategoryName = "FITNESS"
            },
            new()
            {
                CoachCategoryId    = 1,
                CoachCategoryName = "GROUP FITNESS INSTRUCTOR"
            },
            new()
            {
                CoachCategoryId    = 2,
                CoachCategoryName = "CROSS FIT TRAINER"
            },
            new()
            {
                CoachCategoryId    = 3,
                CoachCategoryName = "REHABILITATION"
            },
            new()
            {
                CoachCategoryId    = 4,
                CoachCategoryName = "CORE STRENGTHENING"
            },
            new()
            {
                CoachCategoryId    = 5,
                CoachCategoryName = "BODYBUILDING"
            },
            new()
            {
                CoachCategoryId    = 6,
                CoachCategoryName = "WEIGHT LOSS"
            },
            new()
            {
                CoachCategoryId    = 7,
                CoachCategoryName = "CARDIOVASCULAR"
            },
        };
        modelBuilder.HasData(coachCategories);
    }
}