using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class BodyPart
{
    public Guid BodyPartUid { get; set; }

    public string BodyPartName { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
