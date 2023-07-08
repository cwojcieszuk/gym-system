using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class BodyPart
{
    public string IdBodyPart { get; set; }

    public string BodyPartName { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
