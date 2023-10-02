using Gymify.Domain.Entities;
using Gymify.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class AspNetRoleConfiguration : IEntityTypeConfiguration<AspNetRole>
{
    public void Configure(EntityTypeBuilder<AspNetRole> builder)
    {
        builder.Seed();
    }
}