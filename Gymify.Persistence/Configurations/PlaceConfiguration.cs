using Gymify.Domain.Constants.Column;
using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.ToTable(nameof(Place));
        
        builder.HasKey(e => e.PlaceId).HasName("Place_pk");

        builder.Property(e => e.PlaceId).ValueGeneratedNever();
        builder.Property(e => e.PlaceName)
            .HasMaxLength(GroupSessionColumnConstants.PlaceNameLimit)
            .IsUnicode(false)
            .HasColumnName("PlaceName");
    }
}