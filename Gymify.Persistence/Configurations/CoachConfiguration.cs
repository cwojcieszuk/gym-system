using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class CoachConfiguration : IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        builder.ToTable(nameof(Coach));
        
        builder.HasKey(e => e.CoachUid).HasName("Coach_pk");

        builder.Property(e => e.CoachUid).ValueGeneratedNever();

        builder.Property(e => e.Description)
            .HasMaxLength(CoachColumnConstants.DescriptionLimit)
            .IsUnicode(false);
        
        builder.HasOne(d => d.User).WithOne(p => p.Coach)
            .HasForeignKey<Coach>(d => d.CoachUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Coach_AspNetUsers");
    }
}