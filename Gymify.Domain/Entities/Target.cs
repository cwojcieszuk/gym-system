using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Target
{
    public string IdTarget { get; set; }

    public string TargetName { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
