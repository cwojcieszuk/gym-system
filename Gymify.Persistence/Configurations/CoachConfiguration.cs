using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class CoachConfiguration : IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        builder.HasKey(e => e.IdCoach).HasName("Coach_pk");

        builder.ToTable("Coach");

        builder.Property(e => e.Description)
            .HasMaxLength(300)
            .IsUnicode(false);

        builder.HasOne(d => d.IdCoachNavigation).WithOne(p => p.Coach)
            .HasForeignKey<Coach>(d => d.IdCoach)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Coach_AspNetUsers");
    }
}