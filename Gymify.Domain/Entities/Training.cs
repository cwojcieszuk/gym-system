using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Training
{
    public Guid TrainingUid { get; set; }

    public DateTime TrainingDate { get; set; }

    public string TrainingName { get; set; } = null!;
    
    public bool IsCyclical { get; set; }

    public Guid TemplateUid { get; set; }

    public virtual Template Template { get; set; } = null!;

    public virtual ICollection<UserTraining> UserTrainings { get; set; } = new List<UserTraining>();
}
