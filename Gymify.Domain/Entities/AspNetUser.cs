using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Gymify.Domain.Entities;

public partial class AspNetUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }

    public string Gender { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public byte[] Avatar { get; set; } = null!;

    public virtual Client? Client { get; set; }

    public virtual Coach? Coach { get; set; }

    public virtual ICollection<FavouriteExercise> FavouriteExercises { get; set; } = new List<FavouriteExercise>();

    public virtual ICollection<UserTraining> UserTrainings { get; set; } = new List<UserTraining>();
}
