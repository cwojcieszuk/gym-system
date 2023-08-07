using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Interfaces;

public interface IGymifyDbContext
{
    DbSet<AspNetUser> AspNetUsers { get; set; }
    
    DbSet<BodyPart> BodyParts { get; set; }

    DbSet<Client> Clients { get; set; }

    DbSet<Coach> Coaches { get; set; }

    DbSet<CoachCategory> CoachCategories { get; set; }

    DbSet<CoachHour> CoachHours { get; set; }

    DbSet<DifficultyLevel> DifficultyLevels { get; set; }

    DbSet<Equipment> Equipment { get; set; }

    DbSet<Exercise> Exercises { get; set; }

    DbSet<FavouriteCoach> FavouriteCoaches { get; set; }

    DbSet<FavouriteExercise> FavouriteExercises { get; set; }

    DbSet<GroupSession> GroupSessions { get; set; }

    DbSet<Place> Places { get; set; }

    DbSet<Target> Targets { get; set; }

    DbSet<Template> Templates { get; set; }

    DbSet<TemplateExercise> TemplateExercises { get; set; }
    
    DbSet<Training> Training { get; set; }

    DbSet<UserTraining> UserTrainings { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}