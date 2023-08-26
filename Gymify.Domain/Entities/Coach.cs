using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Coach
{
    public Guid CoachUid { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CoachHour> CoachHours { get; set; } = new List<CoachHour>();

    public virtual ICollection<FavouriteCoach> FavouriteCoaches { get; set; } = new List<FavouriteCoach>();

    public virtual ICollection<GroupSession> GroupSessions { get; set; } = new List<GroupSession>();

    public virtual AspNetUser User { get; set; }

    public virtual ICollection<CoachType> CoachTypes { get; set; } = new List<CoachType>();
}
