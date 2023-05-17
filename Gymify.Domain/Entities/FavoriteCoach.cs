﻿using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class FavoriteCoach
{
    public int IdFavoriteCoach { get; set; }

    public string IdClient { get; set; } = null!;

    public string IdCoach { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Coach IdCoachNavigation { get; set; } = null!;
}