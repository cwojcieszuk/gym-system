using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class CoachCategory
{
    public Guid CoachCategoryUid { get; set; }

    public string CoachCategoryName { get; set; } = null!;

    public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();
}
