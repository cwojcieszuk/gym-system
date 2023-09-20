using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Seeds;

public static class TargetSeed
{
    public static void Seed(this EntityTypeBuilder<Target> modelBuilder)
    {
        List<Target> targets = new()
        {
            new Target()
            {
              TargetId  = 0,
              TargetName = "Abs"
            },
            new Target()
            {
                TargetId  = 1,
                TargetName = "Quads"
            },
            new Target()
            {
                TargetId  = 2,
                TargetName = "Lats"
            },
            new Target()
            {
                TargetId  = 3,
                TargetName = "Calves"
            },
            new Target()
            {
                TargetId  = 4,
                TargetName = "Pectorals"
            },
            new Target()
            {
                TargetId  = 5,
                TargetName = "Glutes"
            },
            new Target()
            {
                TargetId  = 6,
                TargetName = "Hamstrings"
            },
            new Target()
            {
                TargetId  = 7,
                TargetName = "Adductors"
            },new Target()
            {
                TargetId  = 8,
                TargetName = "Triceps"
            },
            new Target()
            {
                TargetId  = 9,
                TargetName = "Cardiovascular system"
            },
            new Target()
            {
                TargetId  = 10,
                TargetName = "Spine"
            },
            new Target()
            {
                TargetId  = 11,
                TargetName = "Upper back"
            },
            new Target()
            {
                TargetId  = 12,
                TargetName = "Biceps"
            },
            new Target()
            {
                TargetId  = 13,
                TargetName = "Delts"
            },
            new Target()
            {
                TargetId  = 14,
                TargetName = "Forearms"
            },
            new Target()
            {
                TargetId  = 15,
                TargetName = "Traps"
            },
            new Target()
            {
                TargetId  = 16,
                TargetName = "Serratus anterior"
            },
            new Target()
            {
                TargetId  = 17,
                TargetName = "Abductors"
            },
            new Target()
            {
                TargetId  = 18,
                TargetName = "Levator scapulae"
            },
        };
        modelBuilder.HasData(targets);
    }
}