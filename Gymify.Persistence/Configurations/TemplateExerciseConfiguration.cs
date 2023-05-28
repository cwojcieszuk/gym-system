using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class TemplateExerciseConfiguration : IEntityTypeConfiguration<TemplateExercise>
{
    public void Configure(EntityTypeBuilder<TemplateExercise> builder)
    {
        builder.HasKey(e => new { e.IdExercise, e.IdTemplate, e.IdTemplateExercise }).HasName("TemplateExercise_pk");

        builder.ToTable("TemplateExercise");

        builder.Property(e => e.Comments)
            .HasMaxLength(160)
            .IsUnicode(false);

        builder.HasOne(d => d.IdExerciseNavigation).WithMany(p => p.TemplateExercises)
            .HasForeignKey(d => d.IdExercise)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Table_9_Exercise");

        builder.HasOne(d => d.IdTemplateNavigation).WithMany(p => p.TemplateExercises)
            .HasForeignKey(d => d.IdTemplate)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("TemplateExercise_Template");
    }
}