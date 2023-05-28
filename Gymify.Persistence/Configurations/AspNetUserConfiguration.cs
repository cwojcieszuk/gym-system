using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class AspNetUserConfiguration : IEntityTypeConfiguration<AspNetUser>
{
    public void Configure(EntityTypeBuilder<AspNetUser> builder)
    {
        builder.Property(e => e.Birthdate).HasColumnType("date");
        builder.Property(e => e.CreatedAt).HasColumnType("datetime");
        builder.Property(e => e.Email).HasMaxLength(256);
        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.Gender)
            .HasMaxLength(30)
            .IsUnicode(false);
        builder.Property(e => e.LastName).HasMaxLength(100);
        builder.Property(e => e.NormalizedEmail).HasMaxLength(256);
        builder.Property(e => e.NormalizedUserName).HasMaxLength(256);
        builder.Property(e => e.UserName).HasMaxLength(256);
    }
}