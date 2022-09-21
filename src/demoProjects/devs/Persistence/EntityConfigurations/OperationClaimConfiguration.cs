using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    internal class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(128);

            var operationClaimSeeds = new List<OperationClaim>
            {
                new(1, "Language.Add"), new(2, "Language.Update"), new(3, "Language.Delete"),
                new(4, "Technology.Add"), new(5, "Technology.Update"), new(6, "Technology.Delete"),
            };
            builder.HasData(operationClaimSeeds);
        }
    }
}
