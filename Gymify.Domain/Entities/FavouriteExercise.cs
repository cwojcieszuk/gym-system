﻿using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class FavouriteExercise
{
    public int FavouriteExercise1 { get; set; }

    public int IdExercise { get; set; }

    public string IdUser { get; set; } = null!;

    public virtual Exercise IdExerciseNavigation { get; set; } = null!;

    public virtual AspNetUser IdUserNavigation { get; set; } = null!;
}
