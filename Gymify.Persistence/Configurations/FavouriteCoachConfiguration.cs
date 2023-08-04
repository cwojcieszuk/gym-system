using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class FavouriteCoachConfiguration : IEntityTypeConfiguration<FavouriteCoach>
{
    public void Configure(EntityTypeBuilder<FavouriteCoach> builder)
    {
        builder.ToTable(nameof(FavouriteCoach));
        
        builder.HasKey(e => new { e.FavouriteCoachUid, e.ClientUid, e.CoachUid }).HasName("FavouriteCoach_pk");

        builder.Property(e => e.FavouriteCoachUid).ValueGeneratedNever();
        
        builder.HasOne(d => d.Client).WithMany(p => p.FavouriteCoaches)
            .HasForeignKey(d => d.ClientUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FavouriteCoach_Client");

        builder.HasOne(d => d.Coach).WithMany(p => p.FavouriteCoaches)
            .HasForeignKey(d => d.CoachUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FavouriteCoach_Coach");
    }
}