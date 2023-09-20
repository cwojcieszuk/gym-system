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
                CoachCategoryName = "Fitness"
            },
            new()
            {
                CoachCategoryId    = 1,
                CoachCategoryName = "Group fitness instructor"
            },
            new()
            {
                CoachCategoryId    = 2,
                CoachCategoryName = "Cross fit trainer"
            },
            new()
            {
                CoachCategoryId    = 3,
                CoachCategoryName = "Rehabilitation"
            },
            new()
            {
                CoachCategoryId    = 4,
                CoachCategoryName = "Core Strengthening"
            },
            new()
            {
                CoachCategoryId    = 5,
                CoachCategoryName = "Bodybuilding"
            },
            new()
            {
                CoachCategoryId    = 6,
                CoachCategoryName = "Weight loss"
            },
            new()
            {
                CoachCategoryId    = 7,
                CoachCategoryName = "Cardiovascular"
            },
        };
        modelBuilder.HasData(coachCategories);
    }
}