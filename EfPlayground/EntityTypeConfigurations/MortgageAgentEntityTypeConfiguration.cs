using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EfPlayground.EntityTypeConfigurations
{
    public class MortgageAgentEntityTypeConfiguration : IEntityTypeConfiguration<MortgageAgent>
    {
        public void Configure(EntityTypeBuilder<MortgageAgent> builder)
        {
            builder.ToTable("MortgageAgent", "dbo");
            builder.HasKey(k => new { k.Number, k.Active, k.RecordedDate });

            builder
              .Property(b => b.Active)
              .HasColumnName("Active")
              .HasColumnType("int")
              .IsRequired();

            builder
              .Property(b => b.HubAgentCode)
              .HasColumnName("HubAgent")
              .HasColumnType("uniqueidentifier")
              .IsRequired(false);

            builder
              .Property(b => b.DirectAgentCode)
              .HasColumnName("DirectAgent")
              .HasColumnType("uniqueidentifier")
              .IsRequired(false);
             
            builder
              .Property(b => b.Number)
              .HasColumnName("Number")
              .HasColumnType("int")
              .IsRequired();

            builder
              .Property(b => b.RecordedDate)
              .HasColumnName("RecordedDate")
              .HasColumnType("datetime")
              .IsRequired();
        }
    }
}
