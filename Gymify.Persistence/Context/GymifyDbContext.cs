﻿using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Persistence.Context;

public partial class GymifyDbContext : IdentityDbContext<AspNetUser>, IGymifyDbContext
{
    public GymifyDbContext()
    {
    }

    public GymifyDbContext(DbContextOptions<GymifyDbContext> options) : base(options)
    {
    }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<BodyPart> BodyParts { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<CoachCategory> CoachCategories { get; set; }

    public virtual DbSet<CoachHour> CoachHours { get; set; }

    public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<FavoriteCoach> FavoriteCoaches { get; set; }

    public virtual DbSet<FavoriteExercise> FavoriteExercises { get; set; }

    public virtual DbSet<GroupSession> GroupSessions { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Target> Targets { get; set; }

    public virtual DbSet<Template> Templates { get; set; }

    public virtual DbSet<TemplateExercise> TemplateExercises { get; set; }
    
    public virtual DbSet<Training> Training { get; set; }

    public virtual DbSet<UserTraining> UserTrainings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymifyDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}