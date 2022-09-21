using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    internal class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.ToTable("Technologies").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(64);
            builder.HasOne(p => p.Language);

            var technologyEntitySeeds = new List<Technology>
            {
                new(1, "ASP.NET", 1), new(2, "Spring", 2), new(3, "SignalR", 1)
            };
            builder.HasData(technologyEntitySeeds);
        }
    }
}
