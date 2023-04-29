using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Place
{
    public int IdPlace { get; set; }

    public string Place1 { get; set; } = null!;

    public virtual ICollection<GroupSession> GroupSessions { get; set; } = new List<GroupSession>();
}
