using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Gymify.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class TargetConfiguration : IEntityTypeConfiguration<Target>
{
    public void Configure(EntityTypeBuilder<Target> builder)
    {
        builder.ToTable(nameof(Target));
        
        builder.HasKey(e => e.TargetId).HasName("Target_pk");

        builder.Property(e => e.TargetId).ValueGeneratedNever();
        builder.Property(e => e.TargetName)
            .HasMaxLength(ExerciseColumnConstants.TargetNameLimit)
            .IsUnicode(false);
        builder.Seed();
    }
}