using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasKey(e => e.IdExercise).HasName("Exercise_pk");

        builder.ToTable("Exercise");

        builder.Property(e => e.IdExercise).ValueGeneratedNever();
        builder.Property(e => e.ExerciseName)
            .HasMaxLength(128)
            .IsUnicode(false);
        builder.Property(e => e.GifUrl)
            .HasMaxLength(256)
            .IsUnicode(false);

        builder.HasOne(d => d.IdBodyPartNavigation).WithMany(p => p.Exercises)
            .HasForeignKey(d => d.IdBodyPart)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Exercise_BodyPart");

        builder.HasOne(d => d.IdEquipmentNavigation).WithMany(p => p.Exercises)
            .HasForeignKey(d => d.IdEquipment)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Exercise_Equipment");

        builder.HasOne(d => d.IdTargetNavigation).WithMany(p => p.Exercises)
            .HasForeignKey(d => d.IdTarget)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Exercise_Target");
    }
}