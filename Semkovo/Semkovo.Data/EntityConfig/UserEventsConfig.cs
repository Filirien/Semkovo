using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Semkovo.Data.Models;
using System;

namespace Semkovo.Data.EntityConfig
{
    public class UserEventsConfig : IEntityTypeConfiguration<UserEvents>
    {
        public void Configure(EntityTypeBuilder<UserEvents> builder)
        {
            builder.HasKey(e => new { e.EventId, e.ParticipantId });

            builder
                .HasOne(ue => ue.Event)
                .WithMany(e => e.Participants)
                .HasForeignKey(ue => ue.EventId);

            builder
                .HasOne(ue => ue.Participant)
                .WithMany(p => p.SubscribedEvents)
                .HasForeignKey(ue => ue.ParticipantId);
        }
        
    }
}
