using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class UserTraining
{
    public Guid UserTrainingUid { get; set; }

    public Guid TrainingUid { get; set; }

    public Guid UserUid { get; set; }

    public virtual Training Training { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
