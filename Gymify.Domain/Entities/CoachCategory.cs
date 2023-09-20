using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class CoachCategory
{
    public int CoachCategoryId { get; set; }

    public string CoachCategoryName { get; set; } = null!;

    public virtual ICollection<CoachType> CoachTypes { get; set; } = new List<CoachType>();
}
