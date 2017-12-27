using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Semkovo.Data.Models;
using System;

namespace Semkovo.Data.EntityConfig
{

    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedOn)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
