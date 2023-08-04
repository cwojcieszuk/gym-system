using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class TrainingConfiguration : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.HasKey(e => e.TrainingUid).HasName("Training_pk");

        builder.Property(e => e.TrainingUid).ValueGeneratedNever();
        builder.Property(e => e.TrainingDate).HasColumnType("date");
        builder.Property(e => e.TrainingName)
            .HasMaxLength(TrainingColumnConstants.TrainingNameLimit)
            .IsUnicode(false);

        builder.HasOne(d => d.Template).WithMany(p => p.Training)
            .HasForeignKey(d => d.TemplateUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Training_Template");
    }
}