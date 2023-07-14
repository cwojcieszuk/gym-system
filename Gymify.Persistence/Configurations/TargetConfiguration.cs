using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class TargetConfiguration : IEntityTypeConfiguration<Target>
{
    public void Configure(EntityTypeBuilder<Target> builder)
    {
        builder.ToTable(nameof(Target));
        
        builder.HasKey(e => e.TargetUid).HasName("Target_pk");

        builder.Property(e => e.TargetUid).ValueGeneratedNever();
        builder.Property(e => e.TargetName)
            .HasMaxLength(ExerciseColumnConstants.TargetNameLimit)
            .IsUnicode(false);
    }
}