using Microsoft.EntityFrameworkCore;
using Semkovo.Data.EntityConfig;
using Semkovo.Data.Models;

namespace Semkovo.Data
{
    public class SemkovoDbContext : DbContext
    {
        public SemkovoDbContext(DbContextOptions<SemkovoDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ArticleVote> ArticleVotes { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new ArticleConfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new ArticleVoteConfig());
            builder.ApplyConfiguration(new PictureConfig());

            base.OnModelCreating(builder);
        }
    }
}
