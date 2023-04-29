using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Exercise
{
    public int IdExercise { get; set; }

    public string ExerciseName { get; set; } = null!;

    public int IdBodyPart { get; set; }

    public int IdTarget { get; set; }

    public int IdEquipment { get; set; }

    public string GifUrl { get; set; } = null!;

    public virtual ICollection<FavoriteExercise> FavoriteExercises { get; set; } = new List<FavoriteExercise>();

    public virtual BodyPart IdBodyPartNavigation { get; set; } = null!;

    public virtual Equipment IdEquipmentNavigation { get; set; } = null!;

    public virtual Target IdTargetNavigation { get; set; } = null!;

    public virtual ICollection<TemplateExercise> TemplateExercises { get; set; } = new List<TemplateExercise>();
}
