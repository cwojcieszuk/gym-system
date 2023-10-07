using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Seeds;

public static class AspNetRolesSeed
{
    public static void Seed(this EntityTypeBuilder<AspNetRole> modelBuilder)
    {
        List<AspNetRole> roles = new()
        {
            new ()
            {
                Id = "05349C4C-9CD0-4F12-DE55-08DB9454E081",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = null,
            },
            new ()
            {
                Id = "1804971B-771E-4DB4-DE56-08DB9454E081",
                NormalizedName = "COACH",
                Name = "Coach",
                ConcurrencyStamp = null
            },
            new ()
            {
                Id = "21D8627F-CC59-4297-DE57-08DB9454E081",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = null,
            }
        };
    }
}