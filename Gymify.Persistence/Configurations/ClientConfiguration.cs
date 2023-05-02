using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(e => e.IdClient).HasName("Client_pk");

        builder.ToTable("Client");

        builder.HasOne(d => d.IdClientNavigation).WithOne(p => p.Client)
            .HasForeignKey<Client>(d => d.IdClient)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Client_AspNetUsers");
    }
}