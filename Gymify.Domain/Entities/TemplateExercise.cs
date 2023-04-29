using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class TemplateExercise
{
    public int IdTemplateExercise { get; set; }

    public int IdExercise { get; set; }

    public int IdTemplate { get; set; }

    public int NumberOfSets { get; set; }

    public int NumberOfReps { get; set; }

    public string Comments { get; set; } = null!;

    public virtual Exercise IdExerciseNavigation { get; set; } = null!;

    public virtual Template IdTemplateNavigation { get; set; } = null!;
}
