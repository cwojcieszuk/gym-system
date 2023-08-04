using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class UserTrainingConfiguration : IEntityTypeConfiguration<UserTraining>
{
    public void Configure(EntityTypeBuilder<UserTraining> builder)
    {
        builder.ToTable(nameof(UserTraining));
        
        builder.HasKey(e => new { e.UserTrainingUid, e.UserUid, e.TrainingUid }).HasName("UserTraining_pk");

        builder.Property(e => e.UserTrainingUid).ValueGeneratedNever();

        builder.HasOne(d => d.Training).WithMany(p => p.UserTrainings)
            .HasForeignKey(d => d.TrainingUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("UserTraining_Training");

        builder.HasOne(d => d.User).WithMany(p => p.UserTrainings)
            .HasForeignKey(d => d.UserUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("UserTraining_AspNetUsers");
    }
}