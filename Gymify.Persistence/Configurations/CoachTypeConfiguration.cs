using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class CoachTypeConfiguration : IEntityTypeConfiguration<CoachType>
{
    public void Configure(EntityTypeBuilder<CoachType> builder)
    {
        builder.ToTable(nameof(CoachType));

        builder.HasKey(c => new { c.CoachTypeUid, c.CoachUid, c.CoachCategoryUid}).HasName("CoachType_pk");

        builder.Property(c => c.CoachTypeUid).ValueGeneratedNever();

        builder.HasOne(c => c.Coach).WithMany(e => e.CoachTypes)
            .HasForeignKey(c => c.CoachUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("CoachType_Coach");

        builder.HasOne(c => c.CoachCategory).WithMany(e => e.CoachTypes)
            .HasForeignKey(c => c.CoachCategoryUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("CoachType_CoachCategory");
    }
}