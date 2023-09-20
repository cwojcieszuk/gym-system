using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class GroupSessionConfiguration : IEntityTypeConfiguration<GroupSession>
{
    public void Configure(EntityTypeBuilder<GroupSession> builder)
    {
        builder.ToTable(nameof(GroupSession));
        
        builder.HasKey(e => e.GroupSessionUid).HasName("GroupSession_pk");

        builder.Property(e => e.GroupSessionUid).ValueGeneratedNever();
        builder.Property(e => e.Description)
            .HasMaxLength(GroupSessionColumnConstants.SessionDescriptionLimit)
            .IsUnicode(false);
        
        builder.Property(e => e.SessionEndDate).HasColumnType("datetime");
        builder.Property(e => e.SessionName)
            .HasMaxLength(GroupSessionColumnConstants.SessionNameLimit)
            .IsUnicode(false);
        builder.Property(e => e.SessionStartDate).HasColumnType("datetime");

        builder.HasOne(d => d.Coach).WithMany(p => p.GroupSessions)
            .HasForeignKey(d => d.CoachUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("GroupSession_Coach");

        builder.HasOne(d => d.Place).WithMany(p => p.GroupSessions)
            .HasForeignKey(d => d.PlaceId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("GroupSession_Place");
    }
}