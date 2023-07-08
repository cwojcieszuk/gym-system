using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class FavouriteCoachConfiguration : IEntityTypeConfiguration<FavouriteCoach>
{
    public void Configure(EntityTypeBuilder<FavouriteCoach> builder)
    {
        builder.HasKey(e => new { e.IdFavouriteCoach, e.IdClient, e.IdCoach }).HasName("FavouriteCoach_pk");
        
        builder.ToTable("FavouriteCoach");
        
        builder.Property(e => e.IdFavouriteCoach).HasMaxLength(450);
        
        builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.FavouriteCoaches)
            .HasForeignKey(d => d.IdClient)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FavouriteCoach_Client");

        builder.HasOne(d => d.IdCoachNavigation).WithMany(p => p.FavouriteCoaches)
            .HasForeignKey(d => d.IdCoach)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FavouriteCoach_Coach");
    }
}