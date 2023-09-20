using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Seeds;

public static class DifficultyLevelSeed
{
    public static void Seed(this EntityTypeBuilder<DifficultyLevel> modelBuilder)
    {
        List<DifficultyLevel> difficultyLevels = new()
        {
            new()
            {
                DifficultyLevelId = 0,
                DifficultyLevelName = "Easy"
            },
            new()
            {
                DifficultyLevelId = 1,
                DifficultyLevelName = "Medium"
            },
            new()
            {
                DifficultyLevelId = 2,
                DifficultyLevelName = "Hard"
            }
        };
        modelBuilder.HasData(difficultyLevels);
    }
}