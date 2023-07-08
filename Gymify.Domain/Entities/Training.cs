using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Training
{
    public string IdTraining { get; set; }

    public DateTime TrainingDate { get; set; }

    public string TrainingName { get; set; } = null!;

    public string IdTemplate { get; set; }

    public virtual Template IdTemplateNavigation { get; set; } = null!;

    public virtual ICollection<UserTraining> UserTrainings { get; set; } = new List<UserTraining>();
}
