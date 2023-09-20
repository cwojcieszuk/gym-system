using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Seeds;

public static class PlaceSeed
{
    public static void Seed(this EntityTypeBuilder<Place> modelBuilder)
    {
        List<Place> places = new()
        {
            new()
            {
                PlaceId = 0,
                PlaceName = "CARDIO AREA"
            },
            new()
            {
                PlaceId = 1,
                PlaceName = "WEIGHTLIFTING ZONE"
            },
            new()
            {
                PlaceId = 2,
                PlaceName = "FREE WEIGHTS ZONE"
            },
            new()
            {
                PlaceId = 3,
                PlaceName = "WEIGHTLIFTING SECTION"
            },
            new()
            {
                PlaceId = 4,
                PlaceName = "STRETCHING ZONE"
            },
            new()
            {
                PlaceId = 5,
                PlaceName = "GROUP FITNESS STUDIO"
            },
            new()
            {
                PlaceId = 6,
                PlaceName = "MARTIAL ARTS AREA"
            },
            new()
            {
                PlaceId = 7,
                PlaceName = "LOCKER ROOM"
            },
            new()
            {
                PlaceId = 8,
                PlaceName = "SAUNA"
            },
            new()
            {
                PlaceId = 9,
                PlaceName = "MASSAGE AND RECOVERY CENTER"
            },
        };
        modelBuilder.HasData(places);
    }
}