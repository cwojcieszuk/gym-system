using Gymify.Domain.Constants.Column;
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
        builder.Property(e => e.Email).HasMaxLength(UserColumnConstants.EmailLimit);
        builder.Property(e => e.FirstName).HasMaxLength(UserColumnConstants.FirstNameLimit);
        builder.Property(e => e.Gender)
            .HasMaxLength(UserColumnConstants.GenderLimit)
            .IsUnicode(false);
        builder.Property(e => e.LastName).HasMaxLength(UserColumnConstants.LastNameLimit);
        builder.Property(e => e.NormalizedEmail).HasMaxLength(UserColumnConstants.EmailLimit);
        builder.Property(e => e.NormalizedUserName).HasMaxLength(UserColumnConstants.UsernameLimit);
        builder.Property(e => e.UserName).HasMaxLength(UserColumnConstants.UsernameLimit);
    }
}