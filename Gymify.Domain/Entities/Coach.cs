using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Coach
{
    public string IdCoach { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<CoachHour> CoachHours { get; set; } = new List<CoachHour>();

    public virtual ICollection<FavoriteCoach> FavoriteCoaches { get; set; } = new List<FavoriteCoach>();

    public virtual ICollection<GroupSession> GroupSessions { get; set; } = new List<GroupSession>();

    public virtual AspNetUser IdCoachNavigation { get; set; } = null!;

    public virtual ICollection<CoachCategory> IdCoachCategories { get; set; } = new List<CoachCategory>();
}
