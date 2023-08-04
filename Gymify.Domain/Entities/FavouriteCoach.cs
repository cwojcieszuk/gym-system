using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class FavouriteCoach
{
    public Guid FavouriteCoachUid { get; set; }

    public Guid ClientUid { get; set; }

    public Guid CoachUid { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Coach Coach { get; set; } = null!;
}
