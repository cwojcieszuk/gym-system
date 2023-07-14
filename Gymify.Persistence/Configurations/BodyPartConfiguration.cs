using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class BodyPartConfiguration : IEntityTypeConfiguration<BodyPart>
{
    public void Configure(EntityTypeBuilder<BodyPart> builder)
    {
        builder.ToTable(nameof(BodyPart));
        
        builder.HasKey(e => e.BodyPartUid).HasName("BodyPart_pk");
        
        builder.Property(e => e.BodyPartUid).ValueGeneratedNever();
            
        builder.Property(e => e.BodyPartName)
            .HasMaxLength(ExerciseColumnConstants.BodyPartNameLimit)
            .IsUnicode(false);
    }
}