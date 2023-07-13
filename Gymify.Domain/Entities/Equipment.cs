﻿using System;
using System.Collections.Generic;

namespace Gymify.Domain.Entities;

public partial class Equipment
{
    public Guid EquipmentUid { get; set; }

    public string EquipmentName { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
