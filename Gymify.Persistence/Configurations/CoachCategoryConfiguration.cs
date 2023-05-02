using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class CoachCategoryConfiguration : IEntityTypeConfiguration<CoachCategory>
{
    public void Configure(EntityTypeBuilder<CoachCategory> builder)
    {
        builder.HasKey(e => e.IdCoachCategory).HasName("CoachCategory_pk");

        builder.ToTable("CoachCategory");

        builder.Property(e => e.IdCoachCategory).ValueGeneratedNever();
        builder.Property(e => e.CoachCategoryName)
            .HasMaxLength(32)
            .IsUnicode(false);

        builder.HasMany(d => d.IdCoaches).WithMany(p => p.IdCoachCategories)
            .UsingEntity<Dictionary<string, object>>(
                "CoachType",
                r => r.HasOne<Coach>().WithMany()
                    .HasForeignKey("IdCoach")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CoachType_Coach"),
                l => l.HasOne<CoachCategory>().WithMany()
                    .HasForeignKey("IdCoachCategory")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CoachType_CoachCategory"),
                j =>
                {
                    j.HasKey("IdCoachCategory", "IdCoach").HasName("CoachType_pk");
                    j.ToTable("CoachType");
                });
    }
}