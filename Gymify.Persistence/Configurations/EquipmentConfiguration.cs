using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.HasKey(e => e.IdEquipment).HasName("Equipment_pk");

        builder.Property(e => e.IdEquipment).ValueGeneratedNever().HasMaxLength(450);;
        builder.Property(e => e.EquipmentName)
            .HasMaxLength(64)
            .IsUnicode(false);
    }
}