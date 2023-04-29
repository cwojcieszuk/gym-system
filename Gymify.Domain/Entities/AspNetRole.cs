

namespace Gymify.Domain.Entities;

public partial class AspNetRole
{
    public string Name { get; set; } = null!;

    public string Id { get; set; } = null!;

    public string? ConcurrencyStamp { get; set; }

    public string Discriminator { get; set; } = null!;

    public string? NormalizedName { get; set; }

    public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaim>();

    public virtual ICollection<AspNetUser> Users { get; set; } = new List<AspNetUser>();
}
