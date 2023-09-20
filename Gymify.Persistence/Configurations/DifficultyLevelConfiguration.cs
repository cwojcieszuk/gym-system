using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Gymify.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class DifficultyLevelConfiguration : IEntityTypeConfiguration<DifficultyLevel>
{
    public void Configure(EntityTypeBuilder<DifficultyLevel> builder)
    {
        builder.ToTable(nameof(DifficultyLevel));
        
        builder.HasKey(e => e.DifficultyLevelId).HasName("DifficultyLevel_pk");

        builder.Property(e => e.DifficultyLevelId).ValueGeneratedNever();
        builder.Property(e => e.DifficultyLevelName)
            .HasMaxLength(TemplateColumnConstants.DifficultyLevelNameLimit)
            .IsUnicode(false);
        builder.Seed();
    }
}