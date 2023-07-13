using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class BodyPartConfiguration : IEntityTypeConfiguration<BodyPart>
{
    public void Configure(EntityTypeBuilder<BodyPart> builder)
    {
        builder.HasKey(e => e.BodyPartUid).HasName("BodyPart_pk");

        builder.ToTable("BodyPart");

        builder.Property(e => e.BodyPartUid).ValueGeneratedNever();
            
        builder.Property(e => e.BodyPartName)
            .HasMaxLength(64)
            .IsUnicode(false);
    }
}