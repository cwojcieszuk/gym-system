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
                PlaceName = "Cardio area"
            },
            new()
            {
                PlaceId = 1,
                PlaceName = "Weightlifting zone"
            },
            new()
            {
                PlaceId = 2,
                PlaceName = "Free weights zone"
            },
            new()
            {
                PlaceId = 3,
                PlaceName = "Weightlifting section"
            },
            new()
            {
                PlaceId = 4,
                PlaceName = "Stretching zone"
            },
            new()
            {
                PlaceId = 5,
                PlaceName = "Group fitness studio"
            },
            new()
            {
                PlaceId = 6,
                PlaceName = "Martial arts area"
            },
            new()
            {
                PlaceId = 7,
                PlaceName = "Locker room"
            },
            new()
            {
                PlaceId = 8,
                PlaceName = "Sauna"
            },
            new()
            {
                PlaceId = 9,
                PlaceName = "Massage and recovery center"
            },
        };
        modelBuilder.HasData(places);
    }
}