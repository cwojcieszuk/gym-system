using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class TemplateExercise
{
    public string IdTemplateExercise { get; set; }

    public string IdExercise { get; set; }

    public string IdTemplate { get; set; }

    public string NumberOfSets { get; set; }

    public string NumberOfReps { get; set; }

    public string Comments { get; set; } = null!;

    public virtual Exercise IdExerciseNavigation { get; set; } = null!;

    public virtual Template IdTemplateNavigation { get; set; } = null!;
}
