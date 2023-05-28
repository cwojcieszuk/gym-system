﻿using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Client
{
    public string IdClient { get; set; } = null!;

    public virtual ICollection<CoachHour> CoachHours { get; set; } = new List<CoachHour>();

    public virtual ICollection<FavouriteCoach> FavouriteCoaches { get; set; } = new List<FavouriteCoach>();

    public virtual AspNetUser IdClientNavigation { get; set; } = null!;

    public virtual ICollection<GroupSession> IdGroupSessions { get; set; } = new List<GroupSession>();
}
