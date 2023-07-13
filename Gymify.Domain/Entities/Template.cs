using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Template
{
    public Guid TemplateUid { get; set; }

    public string TemplateName { get; set; } = null!;

    public Guid DifficultyLevelUid { get; set; }

    public decimal EstimatedTime { get; set; }

    public bool IsShared { get; set; }

    public virtual DifficultyLevel DifficultyLevel { get; set; } = null!;

    public virtual ICollection<TemplateExercise> TemplateExercises { get; set; } = new List<TemplateExercise>();

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
