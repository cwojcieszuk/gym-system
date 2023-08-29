using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class TemplateConfiguration : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.ToTable(nameof(Template));
        
        builder.HasKey(e => e.TemplateUid).HasName("Template_pk");

        builder.Property(e => e.TemplateUid).ValueGeneratedNever();
        builder.Property(e => e.EstimatedTime).HasColumnType("numeric(3, 0)");
        builder.Property(e => e.TemplateName)
            .HasMaxLength(TemplateColumnConstants.TemplateNameLimit)
            .IsUnicode(false);

        builder.HasOne(d => d.DifficultyLevel).WithMany(p => p.Templates)
            .HasForeignKey(d => d.DifficultyLevelUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Template_DifficultyLevel");

        builder.HasOne(x => x.User).WithMany(x => x.Templates)
            .HasForeignKey(x => x.UserUid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Template_User");
    }
}