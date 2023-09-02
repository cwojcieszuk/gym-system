using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable(nameof(Exercise));
        
        builder.HasKey(e => e.ExerciseUid).HasName("Exercise_pk");

        builder.Property(e => e.ExerciseUid).ValueGeneratedNever();
        
        builder.Property(e => e.ExerciseName)
            .HasMaxLength(ExerciseColumnConstants.ExerciseNameLimit)
            .IsUnicode(false);

        builder.HasOne(d => d.BodyPart).WithMany(p => p.Exercises)
            .HasForeignKey(d => d.BodyPartId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Exercise_BodyPart");

        builder.HasOne(d => d.Equipment).WithMany(p => p.Exercises)
            .HasForeignKey(d => d.EquipmentId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Exercise_Equipment");

        builder.HasOne(d => d.Target).WithMany(p => p.Exercises)
            .HasForeignKey(d => d.TargetId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Exercise_Target");
    }
}