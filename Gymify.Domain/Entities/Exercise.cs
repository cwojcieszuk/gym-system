using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Exercise
{
    public Guid ExerciseUid { get; set; }

    public string ExerciseName { get; set; } = null!;

    public int BodyPartId { get; set; }

    public int TargetId { get; set; }

    public int EquipmentId { get; set; }

    public string GifUrl { get; set; } = null!;

    public virtual ICollection<FavouriteExercise> FavouriteExercises { get; set; } = new List<FavouriteExercise>();

    public virtual BodyPart BodyPart { get; set; } = null!;

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual Target Target { get; set; } = null!;

    public virtual ICollection<TemplateExercise> TemplateExercises { get; set; } = new List<TemplateExercise>();
}
