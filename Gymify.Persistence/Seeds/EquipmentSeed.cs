using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Seeds;

public static class EquipmentSeed
{
    public static void Seed(this EntityTypeBuilder<Equipment> modelBuilder)
    {
        List<Equipment> equipments = new()
        {
            new Equipment()
            {
                EquipmentId = 0,
                EquipmentName = "Body weight"
            },
            new Equipment()
            {
                EquipmentId = 1,
                EquipmentName = "Cable"
            },
            new Equipment()
            {
                EquipmentId = 2,
                EquipmentName = "Leverage machine"
            },
            new Equipment()
            {
                EquipmentId = 3,
                EquipmentName = "Assisted"
            },
            new Equipment()
            {
                EquipmentId = 4,
                EquipmentName = "Medicine ball"
            },
            new Equipment()
            {
                EquipmentId = 5,
                EquipmentName = "Stability ball"
            },
            new Equipment()
            {
                EquipmentId = 6,
                EquipmentName = "Band"
            },
            new Equipment()
            {
                EquipmentId = 7,
                EquipmentName = "Barbell"
            },
            new Equipment()
            {
                EquipmentId = 8,
                EquipmentName = "Rope"
            },
            new Equipment()
            {
                EquipmentId = 9,
                EquipmentName = "Dumbell"
            },
            new Equipment()
            {
                EquipmentId = 10,
                EquipmentName = "Ez barbell"
            },
            new Equipment()
            {
                EquipmentId = 11,
                EquipmentName = "Sled machine"
            },  
            new Equipment()
            {
                EquipmentId = 12,
                EquipmentName = "Upper body ergometer"
            },
            new Equipment()
            {
                EquipmentId = 13,
                EquipmentName = "Kettlebell"
            },
            new Equipment()
            {
                EquipmentId = 14,
                EquipmentName = "Olympic barbell"
            },
            new Equipment()
            {
                EquipmentId = 15,
                EquipmentName = "Weighted"
            },
            new Equipment()
            {
                EquipmentId = 16,
                EquipmentName = "Bosu ball"
            },
            new Equipment()
            {
                EquipmentId = 17,
                EquipmentName = "Resistance band"
            },
            new Equipment()
            {
                EquipmentId = 18,
                EquipmentName = "Roller"
            },
            new Equipment()
            {
                EquipmentId = 19,
                EquipmentName = "Skierg machine"
            },
            new Equipment()
            {
                EquipmentId = 20,
                EquipmentName = "Hammer"
            },
            new Equipment()
            {
                EquipmentId = 21,
                EquipmentName = "Smith machine"
            },
            new Equipment()
            {
                EquipmentId = 22,
                EquipmentName = "Wheel roller"
            },
            new Equipment()
            {
                EquipmentId = 23,
                EquipmentName = "Stationary bike"
            },
            new Equipment()
            {
                EquipmentId = 24,
                EquipmentName = "Tire"
            },
            new Equipment()
            {
                EquipmentId = 25,
                EquipmentName = "Trap bar"
            },
            new Equipment()
            {
                EquipmentId = 26,
                EquipmentName = "Elliptical machine"
            },
            new Equipment()
            {
                EquipmentId = 27,
                EquipmentName = "Stepmill machine"
            },
        };
        modelBuilder.HasData(equipments);
    }
}