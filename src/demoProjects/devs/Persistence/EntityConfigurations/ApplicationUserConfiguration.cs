using Core.Security.Enums;
using Core.Security.Hashing;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.UserId).HasColumnName("UserId");
            builder.Property(p => p.GitHubAddress).HasColumnName("GitHubAddress").HasMaxLength(128);
            builder.HasOne(d => d.User);

            HashingHelper.CreatePasswordHash("Pass123", out var passwordHash, out var passwordSalt);
            var applicationUserSeeds = new List<ApplicationUser>
            {
                new(1, 1, "https://github.com/tuncayalt")
            };
            builder.HasData(applicationUserSeeds);
        }
    }
}
