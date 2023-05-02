using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class FavoriteExerciseConfiguration : IEntityTypeConfiguration<FavoriteExercise>
{
    public void Configure(EntityTypeBuilder<FavoriteExercise> builder)
    {
        builder.HasKey(e => new { e.IdExercise, e.IdUser, e.FavoriteExercise1 }).HasName("FavoriteExercise_pk");

        builder.ToTable("FavoriteExercise");

        builder.Property(e => e.FavoriteExercise1).HasColumnName("FavoriteExercise");

        builder.HasOne(d => d.IdExerciseNavigation).WithMany(p => p.FavoriteExercises)
            .HasForeignKey(d => d.IdExercise)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("UserExercise_Exercise");

        builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.FavoriteExercises)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FavoriteExercise_AspNetUsers");
    }
}