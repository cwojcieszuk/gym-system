using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(e => e.ClientUid).HasName("Client_pk");
        
        builder.Property(e => e.ClientUid).ValueGeneratedNever();
        builder.ToTable("Client");

        builder.HasOne(d => d.User).WithOne(p => p.Client)
            .HasForeignKey<Client>(d => d.ClientUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Client_AspNetUsers");
    }
}