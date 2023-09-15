using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Place
{
    public int PlaceId { get; set; }

    public string PlaceName { get; set; } = null!;

    public virtual ICollection<GroupSession> GroupSessions { get; set; } = new List<GroupSession>();
}
