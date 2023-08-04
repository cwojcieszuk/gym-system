using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class TemplateExercise
{
    public Guid TemplateExerciseUid { get; set; }

    public Guid ExerciseUid { get; set; }

    public Guid TemplateUid { get; set; }

    public string NumberOfSets { get; set; }

    public string NumberOfReps { get; set; }

    public string Comments { get; set; } = null!;

    public virtual Exercise Exercise { get; set; } = null!;

    public virtual Template Template { get; set; } = null!;
}
