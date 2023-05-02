using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class FavoriteCoachConfiguration : IEntityTypeConfiguration<FavoriteCoach>
{
    public void Configure(EntityTypeBuilder<FavoriteCoach> builder)
    {
        builder.HasKey(e => new { e.IdFavoriteCoach, e.IdClient, e.IdCoach }).HasName("FavoriteCoach_pk");

        builder.ToTable("FavoriteCoach");

        builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.FavoriteCoaches)
            .HasForeignKey(d => d.IdClient)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FavoriteCoach_Client");

        builder.HasOne(d => d.IdCoachNavigation).WithMany(p => p.FavoriteCoaches)
            .HasForeignKey(d => d.IdCoach)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FavoriteCoach_Coach");
    }
}