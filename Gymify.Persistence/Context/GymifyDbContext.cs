using System;
using System.Collections.Generic;
using Gymify.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Persistence.Context;

public partial class GymifyDbContext : IdentityDbContext<AspNetUser>
{
    public GymifyDbContext()
    {
    }

    public GymifyDbContext(DbContextOptions<GymifyDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=tcp:gymify-sqlserver.database.windows.net,1433;Initial Catalog=gymify;Persist Security Info=False;User ID=pudzian;Password=h%saz$22lq7VJxxj;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<BodyPart>(entity =>
        {
            entity.HasKey(e => e.IdBodyPart).HasName("BodyPart_pk");

            entity.ToTable("BodyPart");

            entity.Property(e => e.IdBodyPart).ValueGeneratedNever();
            entity.Property(e => e.BodyPartName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("Client_pk");

            entity.ToTable("Client");

            entity.HasOne(d => d.IdClientNavigation).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Client_AspNetUsers");
        });

        modelBuilder.Entity<Coach>(entity =>
        {
            entity.HasKey(e => e.IdCoach).HasName("Coach_pk");

            entity.ToTable("Coach");

            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCoachNavigation).WithOne(p => p.Coach)
                .HasForeignKey<Coach>(d => d.IdCoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Coach_AspNetUsers");
        });

        modelBuilder.Entity<CoachCategory>(entity =>
        {
            entity.HasKey(e => e.IdCoachCategory).HasName("CoachCategory_pk");

            entity.ToTable("CoachCategory");

            entity.Property(e => e.IdCoachCategory).ValueGeneratedNever();
            entity.Property(e => e.CoachCategoryName)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasMany(d => d.IdCoaches).WithMany(p => p.IdCoachCategories)
                .UsingEntity<Dictionary<string, object>>(
                    "CoachType",
                    r => r.HasOne<Coach>().WithMany()
                        .HasForeignKey("IdCoach")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("CoachType_Coach"),
                    l => l.HasOne<CoachCategory>().WithMany()
                        .HasForeignKey("IdCoachCategory")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("CoachType_CoachCategory"),
                    j =>
                    {
                        j.HasKey("IdCoachCategory", "IdCoach").HasName("CoachType_pk");
                        j.ToTable("CoachType");
                    });
        });

        modelBuilder.Entity<CoachHour>(entity =>
        {
            entity.HasKey(e => e.CoachHourId).HasName("CoachHour_pk");

            entity.ToTable("CoachHour");

            entity.Property(e => e.CoachHourId).ValueGeneratedNever();
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IdClient).HasMaxLength(450);
            entity.Property(e => e.IdCoach).HasMaxLength(450);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.CoachHours)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("CoachHour_Client");

            entity.HasOne(d => d.IdCoachNavigation).WithMany(p => p.CoachHours)
                .HasForeignKey(d => d.IdCoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CoachHour_Coach");
        });

        modelBuilder.Entity<DifficultyLevel>(entity =>
        {
            entity.HasKey(e => e.IdDifficultyLevel).HasName("DifficultyLevel_pk");

            entity.ToTable("DifficultyLevel");

            entity.Property(e => e.IdDifficultyLevel).ValueGeneratedNever();
            entity.Property(e => e.DifficultyLevelName)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.IdEquipment).HasName("Equipment_pk");

            entity.Property(e => e.IdEquipment).ValueGeneratedNever();
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.IdExercise).HasName("Exercise_pk");

            entity.ToTable("Exercise");

            entity.Property(e => e.IdExercise).ValueGeneratedNever();
            entity.Property(e => e.ExerciseName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.GifUrl)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.IdBodyPartNavigation).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.IdBodyPart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Exercise_BodyPart");

            entity.HasOne(d => d.IdEquipmentNavigation).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.IdEquipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Exercise_Equipment");

            entity.HasOne(d => d.IdTargetNavigation).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.IdTarget)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Exercise_Target");
        });

        modelBuilder.Entity<FavoriteCoach>(entity =>
        {
            entity.HasKey(e => new { e.IdFavoriteCoach, e.IdClient, e.IdCoach }).HasName("FavoriteCoach_pk");

            entity.ToTable("FavoriteCoach");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.FavoriteCoaches)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FavoriteCoach_Client");

            entity.HasOne(d => d.IdCoachNavigation).WithMany(p => p.FavoriteCoaches)
                .HasForeignKey(d => d.IdCoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FavoriteCoach_Coach");
        });

        modelBuilder.Entity<FavoriteExercise>(entity =>
        {
            entity.HasKey(e => new { e.IdExercise, e.IdUser, e.FavoriteExercise1 }).HasName("FavoriteExercise_pk");

            entity.ToTable("FavoriteExercise");

            entity.Property(e => e.FavoriteExercise1).HasColumnName("FavoriteExercise");

            entity.HasOne(d => d.IdExerciseNavigation).WithMany(p => p.FavoriteExercises)
                .HasForeignKey(d => d.IdExercise)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserExercise_Exercise");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.FavoriteExercises)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FavoriteExercise_AspNetUsers");
        });

        modelBuilder.Entity<GroupSession>(entity =>
        {
            entity.HasKey(e => e.IdGroupSession).HasName("GroupSession_pk");

            entity.ToTable("GroupSession");

            entity.Property(e => e.IdGroupSession).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.IdCoach).HasMaxLength(450);
            entity.Property(e => e.SessionEndDate).HasColumnType("datetime");
            entity.Property(e => e.SessionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SessionStartDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdCoachNavigation).WithMany(p => p.GroupSessions)
                .HasForeignKey(d => d.IdCoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GroupSession_Coach");

            entity.HasOne(d => d.IdPlaceNavigation).WithMany(p => p.GroupSessions)
                .HasForeignKey(d => d.IdPlace)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GroupSession_Place");

            entity.HasMany(d => d.IdClients).WithMany(p => p.IdGroupSessions)
                .UsingEntity<Dictionary<string, object>>(
                    "ClientGroupSession",
                    r => r.HasOne<Client>().WithMany()
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ClientGroupSession_Client"),
                    l => l.HasOne<GroupSession>().WithMany()
                        .HasForeignKey("IdGroupSession")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ClientGroupSession_GroupSession"),
                    j =>
                    {
                        j.HasKey("IdGroupSession", "IdClient").HasName("ClientGroupSession_pk");
                        j.ToTable("ClientGroupSession");
                    });
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.IdPlace).HasName("Place_pk");

            entity.ToTable("Place");

            entity.Property(e => e.IdPlace).ValueGeneratedNever();
            entity.Property(e => e.Place1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Place");
        });

        modelBuilder.Entity<Target>(entity =>
        {
            entity.HasKey(e => e.IdTarget).HasName("Target_pk");

            entity.ToTable("Target");

            entity.Property(e => e.IdTarget).ValueGeneratedNever();
            entity.Property(e => e.TargetName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(e => e.IdTemplate).HasName("Template_pk");

            entity.ToTable("Template");

            entity.Property(e => e.IdTemplate).ValueGeneratedNever();
            entity.Property(e => e.EstimatedTime).HasColumnType("numeric(3, 0)");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDifficultyLevelNavigation).WithMany(p => p.Templates)
                .HasForeignKey(d => d.IdDifficultyLevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Template_DifficultyLevel");
        });

        modelBuilder.Entity<TemplateExercise>(entity =>
        {
            entity.HasKey(e => new { e.IdExercise, e.IdTemplate, e.IdTemplateExercise }).HasName("TemplateExercise_pk");

            entity.ToTable("TemplateExercise");

            entity.Property(e => e.Comments)
                .HasMaxLength(160)
                .IsUnicode(false);

            entity.HasOne(d => d.IdExerciseNavigation).WithMany(p => p.TemplateExercises)
                .HasForeignKey(d => d.IdExercise)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_9_Exercise");

            entity.HasOne(d => d.IdTemplateNavigation).WithMany(p => p.TemplateExercises)
                .HasForeignKey(d => d.IdTemplate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TemplateExercise_Template");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.IdTraining).HasName("Training_pk");

            entity.Property(e => e.IdTraining).ValueGeneratedNever();
            entity.Property(e => e.TrainingDate).HasColumnType("date");
            entity.Property(e => e.TrainingName)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTemplateNavigation).WithMany(p => p.Training)
                .HasForeignKey(d => d.IdTemplate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Training_Template");
        });

        modelBuilder.Entity<UserTraining>(entity =>
        {
            entity.HasKey(e => new { e.IdTraining, e.IdUser, e.IdUserTraining }).HasName("UserTraining_pk");

            entity.ToTable("UserTraining");

            entity.HasOne(d => d.IdTrainingNavigation).WithMany(p => p.UserTrainings)
                .HasForeignKey(d => d.IdTraining)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserTraining_Training");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserTrainings)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserTraining_AspNetUsers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
