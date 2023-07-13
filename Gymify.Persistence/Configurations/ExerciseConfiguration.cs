using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasKey(e => e.ExerciseUid).HasName("Exercise_pk");

        builder.ToTable("Exercise");

        builder.Property(e => e.ExerciseUid).ValueGeneratedNever();
        
        builder.Property(e => e.ExerciseName)
            .HasMaxLength(128)
            .IsUnicode(false);
        builder.Property(e => e.GifUrl)
            .HasMaxLength(256)
            .IsUnicode(false);

        builder.HasOne(d => d.BodyPart).WithMany(p => p.Exercises)
            .HasForeignKey(d => d.BodyPartUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Exercise_BodyPart");

        builder.HasOne(d => d.Equipment).WithMany(p => p.Exercises)
            .HasForeignKey(d => d.EquipmentUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Exercise_Equipment");

        builder.HasOne(d => d.Target).WithMany(p => p.Exercises)
            .HasForeignKey(d => d.TargetUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Exercise_Target");
    }
}