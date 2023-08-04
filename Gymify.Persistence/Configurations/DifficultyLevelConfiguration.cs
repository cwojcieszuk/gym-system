using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class DifficultyLevelConfiguration : IEntityTypeConfiguration<DifficultyLevel>
{
    public void Configure(EntityTypeBuilder<DifficultyLevel> builder)
    {
        builder.ToTable(nameof(DifficultyLevel));
        
        builder.HasKey(e => e.DifficultyLevelUid).HasName("DifficultyLevel_pk");

        builder.Property(e => e.DifficultyLevelUid).ValueGeneratedNever();
        builder.Property(e => e.DifficultyLevelName)
            .HasMaxLength(TemplateColumnConstants.DifficultyLevelNameLimit)
            .IsUnicode(false);
    }
}