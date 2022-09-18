using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Technology> Technologies { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(l =>
            {
                l.ToTable("Languages").HasKey(k => k.Id);
                l.Property(p => p.Id).HasColumnName("Id");
                l.Property(p => p.Name).HasColumnName("Name").HasMaxLength(64);
                l.HasMany(p => p.Technologies);
            });
            modelBuilder.Entity<Technology>(t =>
            {
                t.ToTable("Technologies").HasKey(k => k.Id);
                t.Property(p => p.Id).HasColumnName("Id");
                t.Property(p => p.Name).HasColumnName("Name").HasMaxLength(64);
                t.HasOne(p => p.Language);
            });

            var languageEntitySeeds = new List<Language>
            {
                new(1, "C#"), new(2, "Java")
            };
            modelBuilder.Entity<Language>().HasData(languageEntitySeeds);

            var technologyEntitySeeds = new List<Technology>
            {
                new(1, "ASP.NET", 1), new(2, "Spring", 2), new(3, "SignalR", 1)
            };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);

            base.OnModelCreating(modelBuilder);
        }
    }
}
