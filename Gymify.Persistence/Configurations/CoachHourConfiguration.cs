using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class CoachHourConfiguration : IEntityTypeConfiguration<CoachHour>
{
    public void Configure(EntityTypeBuilder<CoachHour> builder)
    {
        builder.ToTable(nameof(CoachHour));
        
        builder.HasKey(e => e.CoachHourUid).HasName("CoachHour_pk");

        builder.Property(e => e.CoachHourUid).ValueGeneratedNever();
        builder.Property(e => e.EndDate).HasColumnType("datetime");
        
        builder.Property(e => e.StartDate).HasColumnType("datetime");

        builder.HasOne(d => d.Client).WithMany(p => p.CoachHours)
            .HasForeignKey(d => d.ClientUid)
            .HasConstraintName("CoachHour_Client");

        builder.HasOne(d => d.Coach).WithMany(p => p.CoachHours)
            .HasForeignKey(d => d.CoachUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("CoachHour_Coach");
    }
}