using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Seeds;

public static class BodyPartSeed
{
    public static void Seed(this EntityTypeBuilder<BodyPart> modelBuilder)
    {
        List<BodyPart> bodyParts = new()
        {
            new()
            {
                BodyPartId = 0,
                BodyPartName = "Waist"
            },
            new()
            {
                BodyPartId = 1,
                BodyPartName = "Upper legs"
            },
            new()
            {
                BodyPartId = 2,
                BodyPartName = "Back"
            },
            new()
            {
                BodyPartId = 3,
                BodyPartName = "Lower legs"
            },
            new()
            {
                BodyPartId = 4,
                BodyPartName = "Chest"
            },
            new()
            {
                BodyPartId = 5,
                BodyPartName = "Upper arms"
            },
            new()
            {
                BodyPartId = 6,
                BodyPartName = "Cardio"
            },
            new()
            {
                BodyPartId = 7,
                BodyPartName = "Shoulders"
            },
            new()
            {
                BodyPartId = 8,
                BodyPartName = "Lower arms"
            },
            new()
            {
                BodyPartId = 9,
                BodyPartName = "Neck"
            },
        };
        modelBuilder.HasData(bodyParts);
    }
}