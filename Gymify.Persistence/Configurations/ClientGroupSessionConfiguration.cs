using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class ClientGroupSessionConfiguration : IEntityTypeConfiguration<ClientGroupSession>
{
    public void Configure(EntityTypeBuilder<ClientGroupSession> builder)
    {
        builder.ToTable(nameof(ClientGroupSession));

        builder.HasKey(c => new { c.ClientGroupSessionUid, c.GroupSessionUid, c.ClientUid }).HasName("ClientGroupSession_pk");

        builder.Property(c => c.ClientGroupSessionUid).ValueGeneratedNever();

        builder.HasOne(c => c.GroupSession).WithMany(c => c.ClientGroupSessions)
            .HasForeignKey(c => c.GroupSessionUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ClientGroupSession_GroupSession");

        builder.HasOne(c => c.Client).WithMany(c => c.ClientGroupSessions)
            .HasForeignKey(c => c.ClientUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ClientGroupSession_Client");

    }
}