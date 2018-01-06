using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Semkovo.Data.EntityConfig;
using Semkovo.Data.Models;

namespace Semkovo.Data
{
    public class SemkovoDbContext : IdentityDbContext<User>
    {
        public SemkovoDbContext(DbContextOptions<SemkovoDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ArticleVote> ArticleVotes { get; set; }
        public DbSet<Event> Events { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new ArticleConfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new ArticleVoteConfig());
            builder.ApplyConfiguration(new PictureConfig());
            builder.ApplyConfiguration(new EventConfig());

            base.OnModelCreating(builder);
        }
    }
}
