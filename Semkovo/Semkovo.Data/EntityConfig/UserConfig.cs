using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Semkovo.Data.Models;

namespace Semkovo.Data.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.FirstName)
                .HasMaxLength(30);
            builder.Property(e => e.LastName)
               .HasMaxLength(30);
            builder.Property(e => e.Email)
               .IsRequired()
               .HasMaxLength(60);
            builder.Property(e => e.Password)
               .IsRequired()
               .HasMaxLength(60);
            builder
                .Ignore(e => e.FullName);

            builder.Property(e => e.IsDeleted)
                .IsRequired(true)
                .HasDefaultValue(false);
        }
    }
}
