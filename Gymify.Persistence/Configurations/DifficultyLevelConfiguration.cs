using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class DifficultyLevelConfiguration : IEntityTypeConfiguration<DifficultyLevel>
{
    public void Configure(EntityTypeBuilder<DifficultyLevel> builder)
    {
        builder.HasKey(e => e.IdDifficultyLevel).HasName("DifficultyLevel_pk");

        builder.ToTable("DifficultyLevel");

        builder.Property(e => e.IdDifficultyLevel).ValueGeneratedNever().HasMaxLength(450);;
        builder.Property(e => e.DifficultyLevelName)
            .HasMaxLength(32)
            .IsUnicode(false);
    }
}