using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class TargetConfiguration : IEntityTypeConfiguration<Target>
{
    public void Configure(EntityTypeBuilder<Target> builder)
    {
        builder.HasKey(e => e.IdTarget).HasName("Target_pk");

        builder.ToTable("Target");

        builder.Property(e => e.IdTarget).ValueGeneratedNever();
        builder.Property(e => e.TargetName)
            .HasMaxLength(64)
            .IsUnicode(false);
    }
}