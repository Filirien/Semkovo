using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Semkovo.Data.Models;

namespace Semkovo.Data.EntityConfig
{
    public class ArticleVoteConfig : IEntityTypeConfiguration<ArticleVote>
    {
        public void Configure(EntityTypeBuilder<ArticleVote> builder)
        {
            builder.HasKey(e => new { e.ArticleId, e.UserId });

            builder.HasOne(e => e.Article)
                .WithMany(a => a.ArticleVotes)
                .HasForeignKey(e => e.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.User)
                .WithMany(u => u.UserVotes)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
