using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(l =>
            {
                l.HasKey(k => k.Id);
            });

            var languageEntitySeeds = new List<Language>
            {
                new(1, "C#"), new(2, "Java")
            };
            modelBuilder.Entity<Language>().HasData(languageEntitySeeds);

            base.OnModelCreating(modelBuilder);
        }
    }
}
