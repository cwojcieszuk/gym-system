using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.HasKey(e => e.EquipmentId).HasName("Equipment_pk");

        builder.Property(e => e.EquipmentId).ValueGeneratedNever();
        builder.Property(e => e.EquipmentName)
            .HasMaxLength(ExerciseColumnConstants.EquipmentNameLimit)
            .IsUnicode(false);
    }
}