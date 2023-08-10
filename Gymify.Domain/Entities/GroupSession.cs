using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class GroupSession
{
    public Guid GroupSessionUid { get; set; }

    public string SessionName { get; set; } = null!;

    public int Slots { get; set; }

    public DateTime SessionStartDate { get; set; }

    public DateTime SessionEndDate { get; set; }

    public string Description { get; set; } = null!;

    public Guid PlaceUid { get; set; }

    public Guid CoachUid { get; set; }

    public virtual Coach Coach { get; set; } = null!;

    public virtual Place Place{ get; set; } = null!;

    public virtual ICollection<ClientGroupSession> ClientGroupSessions { get; set; } = new List<ClientGroupSession>();
}
