using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class BodyPartConfiguration : IEntityTypeConfiguration<BodyPart>
{
    public void Configure(EntityTypeBuilder<BodyPart> builder)
    {
        builder.HasKey(e => e.IdBodyPart).HasName("BodyPart_pk");

        builder.ToTable("BodyPart");

        builder.Property(e => e.IdBodyPart).ValueGeneratedNever();
        builder.Property(e => e.BodyPartName)
            .HasMaxLength(64)
            .IsUnicode(false);
    }
}