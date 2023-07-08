using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class UserTrainingConfiguration : IEntityTypeConfiguration<UserTraining>
{
    public void Configure(EntityTypeBuilder<UserTraining> builder)
    {
        builder.HasKey(e => new { e.IdTraining, e.IdUser, e.IdUserTraining }).HasName("UserTraining_pk");

        builder.ToTable("UserTraining");
        
        builder.Property(e => e.IdUserTraining).HasMaxLength(450);

        builder.HasOne(d => d.IdTrainingNavigation).WithMany(p => p.UserTrainings)
            .HasForeignKey(d => d.IdTraining)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("UserTraining_Training");

        builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserTrainings)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("UserTraining_AspNetUsers");
    }
}