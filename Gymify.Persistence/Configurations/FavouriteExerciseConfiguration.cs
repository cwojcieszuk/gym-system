using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class FavouriteExerciseConfiguration : IEntityTypeConfiguration<FavouriteExercise>
{
    public void Configure(EntityTypeBuilder<FavouriteExercise> builder)
    {
        builder.HasKey(e => new { e.IdExercise, e.IdUser, FavouriteExercise1 = e.IdFavouriteExercise }).HasName("FavouriteExercise_pk");

        builder.ToTable("FavouriteExercise");

        builder.Property(e => e.IdFavouriteExercise).HasColumnName("FavouriteExercise").HasMaxLength(450);
        builder.HasOne(d => d.IdExerciseNavigation).WithMany(p => p.FavouriteExercises)
            .HasForeignKey(d => d.IdExercise)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("UserExercise_Exercise");

        builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.FavouriteExercises)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FavouriteExercise_AspNetUsers");
    }
}