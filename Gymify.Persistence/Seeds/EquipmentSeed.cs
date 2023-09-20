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
                EquipmentName = "BODY WEIGHT"
            },
            new Equipment()
            {
                EquipmentId = 1,
                EquipmentName = "CABLE"
            },
            new Equipment()
            {
                EquipmentId = 2,
                EquipmentName = "LEVERAGE MACHINE"
            },
            new Equipment()
            {
                EquipmentId = 3,
                EquipmentName = "ASSISTED"
            },
            new Equipment()
            {
                EquipmentId = 4,
                EquipmentName = "MEDICINE BALL"
            },
            new Equipment()
            {
                EquipmentId = 5,
                EquipmentName = "STABILITY BALL"
            },
            new Equipment()
            {
                EquipmentId = 6,
                EquipmentName = "BAND"
            },
            new Equipment()
            {
                EquipmentId = 7,
                EquipmentName = "BARBELL"
            },
            new Equipment()
            {
                EquipmentId = 8,
                EquipmentName = "ROPE"
            },
            new Equipment()
            {
                EquipmentId = 9,
                EquipmentName = "DUMBBELL"
            },
            new Equipment()
            {
                EquipmentId = 10,
                EquipmentName = "EZ BARBELL"
            },
            new Equipment()
            {
                EquipmentId = 11,
                EquipmentName = "SLED MACHINE"
            },  
            new Equipment()
            {
                EquipmentId = 12,
                EquipmentName = "UPPER BODY ERGOMETER"
            },
            new Equipment()
            {
                EquipmentId = 13,
                EquipmentName = "KETTLEBELL"
            },
            new Equipment()
            {
                EquipmentId = 14,
                EquipmentName = "OLYMPIC BARBELL"
            },
            new Equipment()
            {
                EquipmentId = 15,
                EquipmentName = "WEIGHTED"
            },
            new Equipment()
            {
                EquipmentId = 16,
                EquipmentName = "BOSU BALL"
            },
            new Equipment()
            {
                EquipmentId = 17,
                EquipmentName = "RESISTANCE BAND"
            },
            new Equipment()
            {
                EquipmentId = 18,
                EquipmentName = "ROLLER"
            },
            new Equipment()
            {
                EquipmentId = 19,
                EquipmentName = "SKIERG MACHINE"
            },
            new Equipment()
            {
                EquipmentId = 20,
                EquipmentName = "HAMMER"
            },
            new Equipment()
            {
                EquipmentId = 21,
                EquipmentName = "SMITH MACHINE"
            },
            new Equipment()
            {
                EquipmentId = 22,
                EquipmentName = "WHEEL ROLLER"
            },
            new Equipment()
            {
                EquipmentId = 23,
                EquipmentName = "STATIONARY BIKE"
            },
            new Equipment()
            {
                EquipmentId = 24,
                EquipmentName = "TIRE"
            },
            new Equipment()
            {
                EquipmentId = 25,
                EquipmentName = "TRAP BAR"
            },
            new Equipment()
            {
                EquipmentId = 26,
                EquipmentName = "ELLIPTICAL MACHINE"
            },
            new Equipment()
            {
                EquipmentId = 27,
                EquipmentName = "STEPMILL MACHINE"
            },
        };
        modelBuilder.HasData(equipments);
    }
}