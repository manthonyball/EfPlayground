using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EfPlayground.EntityTypeConfigurations
{
    public class DirectAgentEntityTypeConfiguration : IEntityTypeConfiguration<DirectAgent>
    {
        public void Configure(EntityTypeBuilder<DirectAgent> builder)
        {
            builder.ToTable("DirectAgent", "dbo");
            builder.HasKey(k => k.Code);

            builder
              .Property(b => b.Active)
              .HasColumnName("Active")
              .HasColumnType("int")
              .IsRequired(false);

            builder
              .Property(b => b.Code)
              .HasColumnName("Code")
              .HasColumnType("uniqueidentifier")
              .IsRequired();
        }
    }
}
