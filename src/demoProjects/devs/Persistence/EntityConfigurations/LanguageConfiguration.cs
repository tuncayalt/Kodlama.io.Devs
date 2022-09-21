using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Persistence.EntityConfigurations
{
    internal class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(64);
            builder.HasMany(p => p.Technologies);

            var languageEntitySeeds = new List<Language>
            {
                new(1, "C#"), new(2, "Java")
            };
            builder.HasData(languageEntitySeeds);
        }
    }
}
