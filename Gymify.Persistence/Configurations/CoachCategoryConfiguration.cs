using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class CoachCategoryConfiguration : IEntityTypeConfiguration<CoachCategory>
{
    public void Configure(EntityTypeBuilder<CoachCategory> builder)
    {
        builder.HasKey(e => e.CoachCategoryUid).HasName("CoachCategory_pk");

        builder.ToTable("CoachCategory");

        builder.Property(e => e.CoachCategoryUid).ValueGeneratedNever();
        
        builder.Property(e => e.CoachCategoryName)
            .HasMaxLength(32)
            .IsUnicode(false);

        builder.HasMany(d => d.Coaches).WithMany(p => p.CoachCategories)
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