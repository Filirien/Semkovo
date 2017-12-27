using Microsoft.EntityFrameworkCore;

namespace Semkovo.Data
{
    public class SemkovoDbContext : DbContext
    {
        public SemkovoDbContext(DbContextOptions<SemkovoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
