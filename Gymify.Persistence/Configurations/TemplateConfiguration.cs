using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class TemplateConfiguration : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.HasKey(e => e.TemplateUid).HasName("Template_pk");

        builder.ToTable("Template");

        builder.Property(e => e.TemplateUid).ValueGeneratedNever();
        builder.Property(e => e.EstimatedTime).HasColumnType("numeric(3, 0)");
        builder.Property(e => e.TemplateName)
            .HasMaxLength(32)
            .IsUnicode(false);

        builder.HasOne(d => d.DifficultyLevel).WithMany(p => p.Templates)
            .HasForeignKey(d => d.DifficultyLevelUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Template_DifficultyLevel");
    }
}