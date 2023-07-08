using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class DifficultyLevel
{
    public string IdDifficultyLevel { get; set; }

    public string DifficultyLevelName { get; set; } = null!;

    public virtual ICollection<Template> Templates { get; set; } = new List<Template>();
}
