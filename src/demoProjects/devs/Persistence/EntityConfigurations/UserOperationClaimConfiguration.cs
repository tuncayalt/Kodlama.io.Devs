using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    internal class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").HasKey(k => k.Id);
            builder.Property(p => p.UserId).HasColumnName("UserId");
            builder.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
            builder.HasOne(p => p.User);
            builder.HasOne(p => p.OperationClaim);

            var userOperationClaimSeeds = new List<UserOperationClaim>
            {
                new(1, 1, 1), new(2, 1, 2), new(3, 1, 3)
            };
            builder.HasData(userOperationClaimSeeds);
        }
    }
}
