using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Gymify.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class BodyPartConfiguration : IEntityTypeConfiguration<BodyPart>
{
    public void Configure(EntityTypeBuilder<BodyPart> builder)
    {
        builder.ToTable(nameof(BodyPart));
        
        builder.HasKey(e => e.BodyPartId).HasName("BodyPart_pk");
        
        builder.Property(e => e.BodyPartId).ValueGeneratedNever();
            
        builder.Property(e => e.BodyPartName)
            .HasMaxLength(ExerciseColumnConstants.BodyPartNameLimit)
            .IsUnicode(false);
        builder.Seed();
    }
}