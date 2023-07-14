using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class TemplateExerciseConfiguration : IEntityTypeConfiguration<TemplateExercise>
{
    public void Configure(EntityTypeBuilder<TemplateExercise> builder)
    {
        builder.ToTable(nameof(TemplateExercise));
        
        builder.HasKey(e => new { e.TemplateExerciseUid, e.ExerciseUid, e.TemplateUid }).HasName("TemplateExercise_pk");

        builder.Property(e => e.TemplateExerciseUid).ValueGeneratedNever();
        
        builder.Property(e => e.Comments)
            .HasMaxLength(TemplateColumnConstants.TemplateCommentsLimit)
            .IsUnicode(false);

        builder.HasOne(d => d.Exercise).WithMany(p => p.TemplateExercises)
            .HasForeignKey(d => d.ExerciseUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("TemplateExercise_Exercise");

        builder.HasOne(d => d.Template).WithMany(p => p.TemplateExercises)
            .HasForeignKey(d => d.TemplateUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("TemplateExercise_Template");
    }
}