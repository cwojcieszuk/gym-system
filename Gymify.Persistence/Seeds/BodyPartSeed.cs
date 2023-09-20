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
                BodyPartName = "WAIST"
            },
            new()
            {
                BodyPartId = 1,
                BodyPartName = "UPPER LEGS"
            },
            new()
            {
                BodyPartId = 2,
                BodyPartName = "BACK"
            },
            new()
            {
                BodyPartId = 3,
                BodyPartName = "LOWER LEGS"
            },
            new()
            {
                BodyPartId = 4,
                BodyPartName = "CHEST"
            },
            new()
            {
                BodyPartId = 5,
                BodyPartName = "UPPER ARMS"
            },
            new()
            {
                BodyPartId = 6,
                BodyPartName = "CARDIO"
            },
            new()
            {
                BodyPartId = 7,
                BodyPartName = "SHOULDERS"
            },
            new()
            {
                BodyPartId = 8,
                BodyPartName = "LOWER ARMS"
            },
            new()
            {
                BodyPartId = 9,
                BodyPartName = "NECK"
            },
        };
        modelBuilder.HasData(bodyParts);
    }
}