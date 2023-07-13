using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class GroupSessionConfiguration : IEntityTypeConfiguration<GroupSession>
{
    public void Configure(EntityTypeBuilder<GroupSession> builder)
    {
        builder.HasKey(e => e.GroupSessionUid).HasName("GroupSession_pk");

        builder.ToTable("GroupSession");

        builder.Property(e => e.GroupSessionUid).ValueGeneratedNever();
        builder.Property(e => e.Description)
            .HasMaxLength(300)
            .IsUnicode(false);
        
        builder.Property(e => e.SessionEndDate).HasColumnType("datetime");
        builder.Property(e => e.SessionName)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.SessionStartDate).HasColumnType("datetime");

        builder.HasOne(d => d.Coach).WithMany(p => p.GroupSessions)
            .HasForeignKey(d => d.CoachUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("GroupSession_Coach");

        builder.HasOne(d => d.Place).WithMany(p => p.GroupSessions)
            .HasForeignKey(d => d.PlaceUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("GroupSession_Place");

        builder.HasMany(d => d.Clients).WithMany(p => p.IdGroupSessions)
            .UsingEntity<Dictionary<string, object>>(
                "ClientGroupSession",
                r => r.HasOne<Client>().WithMany()
                    .HasForeignKey("IdClient")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClientGroupSession_Client"),
                l => l.HasOne<GroupSession>().WithMany()
                    .HasForeignKey("IdGroupSession")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClientGroupSession_GroupSession"),
                j =>
                {
                    j.HasKey("IdGroupSession", "IdClient").HasName("ClientGroupSession_pk");
                    j.ToTable("ClientGroupSession");
                });
    }
}