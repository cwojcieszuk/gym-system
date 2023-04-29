using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class GroupSession
{
    public int IdGroupSession { get; set; }

    public string SessionName { get; set; } = null!;

    public int Slots { get; set; }

    public DateTime SessionStartDate { get; set; }

    public DateTime SessionEndDate { get; set; }

    public string Description { get; set; } = null!;

    public int IdPlace { get; set; }

    public string IdCoach { get; set; } = null!;

    public virtual Coach IdCoachNavigation { get; set; } = null!;

    public virtual Place IdPlaceNavigation { get; set; } = null!;

    public virtual ICollection<Client> IdClients { get; set; } = new List<Client>();
}
