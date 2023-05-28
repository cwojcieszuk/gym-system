using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class CoachHour
{
    public int CoachHourId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string IdCoach { get; set; } = null!;

    public string? IdClient { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Coach IdCoachNavigation { get; set; } = null!;
}
