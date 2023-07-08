using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Exercise
{
    public string IdExercise { get; set; }

    public string ExerciseName { get; set; } = null!;

    public string IdBodyPart { get; set; }

    public string IdTarget { get; set; }

    public string IdEquipment { get; set; }

    public string GifUrl { get; set; } = null!;

    public virtual ICollection<FavouriteExercise> FavouriteExercises { get; set; } = new List<FavouriteExercise>();

    public virtual BodyPart IdBodyPartNavigation { get; set; } = null!;

    public virtual Equipment IdEquipmentNavigation { get; set; } = null!;

    public virtual Target IdTargetNavigation { get; set; } = null!;

    public virtual ICollection<TemplateExercise> TemplateExercises { get; set; } = new List<TemplateExercise>();
}
