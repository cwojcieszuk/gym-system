using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class CoachCategory
{
    public int IdCoachCategory { get; set; }

    public string CoachCategoryName { get; set; } = null!;

    public virtual ICollection<Coach> IdCoaches { get; set; } = new List<Coach>();
}
