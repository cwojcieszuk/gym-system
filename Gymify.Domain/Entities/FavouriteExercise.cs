using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class FavouriteExercise
{
    public Guid FavouriteExerciseUid { get; set; }

    public Guid ExerciseUid { get; set; }

    public Guid UserUid { get; set; }

    public virtual Exercise Exercise { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
