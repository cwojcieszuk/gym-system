﻿using Gymify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymify.Persistence.Configurations;

public class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.HasKey(e => e.IdPlace).HasName("Place_pk");

        builder.ToTable("Place");

        builder.Property(e => e.IdPlace).ValueGeneratedNever();
        builder.Property(e => e.Place1)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("Place");
    }
}