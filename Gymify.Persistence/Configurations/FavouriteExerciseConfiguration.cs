using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class FavouriteExerciseConfiguration : IEntityTypeConfiguration<FavouriteExercise>
{
    public void Configure(EntityTypeBuilder<FavouriteExercise> builder)
    {
        builder.ToTable(nameof(FavouriteExercise));
        
        builder.HasKey(e => new { e.FavouriteExerciseUid, e.UserUid, e.ExerciseUid }).HasName("FavouriteExercise_pk");

        builder.Property(e => e.FavouriteExerciseUid).ValueGeneratedNever();
        
        builder.HasOne(d => d.Exercise).WithMany(p => p.FavouriteExercises)
            .HasForeignKey(d => d.ExerciseUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("UserExercise_Exercise");

        builder.HasOne(d => d.User).WithMany(p => p.FavouriteExercises)
            .HasForeignKey(d => d.UserUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FavouriteExercise_AspNetUsers");
    }
}