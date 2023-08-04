using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class CoachHour
{
    public Guid CoachHourUid { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid CoachUid { get; set; }

    public Guid? ClientUid { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Coach Coach { get; set; }
}
