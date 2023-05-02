using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class CoachHourConfiguration : IEntityTypeConfiguration<CoachHour>
{
    public void Configure(EntityTypeBuilder<CoachHour> builder)
    {
        builder.HasKey(e => e.CoachHourId).HasName("CoachHour_pk");

        builder.ToTable("CoachHour");

        builder.Property(e => e.CoachHourId).ValueGeneratedNever();
        builder.Property(e => e.EndDate).HasColumnType("datetime");
        builder.Property(e => e.IdClient).HasMaxLength(450);
        builder.Property(e => e.IdCoach).HasMaxLength(450);
        builder.Property(e => e.StartDate).HasColumnType("datetime");

        builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.CoachHours)
            .HasForeignKey(d => d.IdClient)
            .HasConstraintName("CoachHour_Client");

        builder.HasOne(d => d.IdCoachNavigation).WithMany(p => p.CoachHours)
            .HasForeignKey(d => d.IdCoach)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("CoachHour_Coach");
    }
}