using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class TrainingConfiguration : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.HasKey(e => e.IdTraining).HasName("Training_pk");

        builder.Property(e => e.IdTraining).ValueGeneratedNever();
        builder.Property(e => e.TrainingDate).HasColumnType("date");
        builder.Property(e => e.TrainingName)
            .HasMaxLength(32)
            .IsUnicode(false);

        builder.HasOne(d => d.IdTemplateNavigation).WithMany(p => p.Training)
            .HasForeignKey(d => d.IdTemplate)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Training_Template");
    }
}