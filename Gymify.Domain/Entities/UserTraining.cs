using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class UserTraining
{
    public int IdUserTraining { get; set; }

    public int IdTraining { get; set; }

    public string IdUser { get; set; } = null!;

    public virtual Training IdTrainingNavigation { get; set; } = null!;

    public virtual AspNetUser IdUserNavigation { get; set; } = null!;
}
