using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    internal class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Token).HasColumnName("Token").HasMaxLength(256);
            builder.Property(p => p.Expires).HasColumnName("Expires");
            builder.Property(p => p.Created).HasColumnName("Created");
            builder.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp").HasMaxLength(32);
            builder.Property(p => p.Revoked).HasColumnName("Revoked");
            builder.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp").HasMaxLength(32);
            builder.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken").HasMaxLength(256);
            builder.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked").HasMaxLength(256);
            builder.HasOne(p => p.User);
        }
    }
}
