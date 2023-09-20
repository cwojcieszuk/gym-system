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
              TargetName = "ABS"
            },
            new Target()
            {
                TargetId  = 1,
                TargetName = "QUADS"
            },
            new Target()
            {
                TargetId  = 2,
                TargetName = "LATS"
            },
            new Target()
            {
                TargetId  = 3,
                TargetName = "CALVES"
            },
            new Target()
            {
                TargetId  = 4,
                TargetName = "PECTORALS"
            },
            new Target()
            {
                TargetId  = 5,
                TargetName = "GLUTES"
            },
            new Target()
            {
                TargetId  = 6,
                TargetName = "HAMSTRINGS"
            },
            new Target()
            {
                TargetId  = 7,
                TargetName = "ADDUCTORS"
            },new Target()
            {
                TargetId  = 8,
                TargetName = "TRICEPS"
            },
            new Target()
            {
                TargetId  = 9,
                TargetName = "CARDIOVASCULAR SYSTEM"
            },
            new Target()
            {
                TargetId  = 10,
                TargetName = "SPINE"
            },
            new Target()
            {
                TargetId  = 11,
                TargetName = "UPPER BACK"
            },
            new Target()
            {
                TargetId  = 12,
                TargetName = "BICEPS"
            },
            new Target()
            {
                TargetId  = 13,
                TargetName = "DELTS"
            },
            new Target()
            {
                TargetId  = 14,
                TargetName = "FOREARMS"
            },
            new Target()
            {
                TargetId  = 15,
                TargetName = "TRAPS"
            },
            new Target()
            {
                TargetId  = 16,
                TargetName = "SERRATUS ANTERIOR"
            },
            new Target()
            {
                TargetId  = 17,
                TargetName = "ABDUCTORS"
            },
            new Target()
            {
                TargetId  = 18,
                TargetName = "LEVATOR SCAPULAE"
            },
        };
        modelBuilder.HasData(targets);
    }
}