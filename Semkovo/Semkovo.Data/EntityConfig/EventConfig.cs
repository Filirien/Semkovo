﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Semkovo.Data.Models;
using System;

namespace Semkovo.Data.EntityConfig
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.StartDate)
                .HasDefaultValue(DateTime.Now);

            builder
                .HasOne(e => e.Creator)
                .WithMany(c => c.CreatedEvents)
                .HasForeignKey(c => c.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
