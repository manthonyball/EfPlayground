using System.Reflection.Metadata;
using EFGetStarted.Models;
using EfPlayground.EntityTypeConfigurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FNContext : DbContext
{
    public DbSet<DirectAgent> DirectAgents { get; set; }
    public DbSet<HubAgent> HubAgents { get; set; }
    public DbSet<MortgageAgent> MortgageAgents { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // => options.UseSqlite($"Data Source={DbPath}");
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = "ATH2\\SQLEXPRESS",
            InitialCatalog = "fn-test",
            IntegratedSecurity = true,
            TrustServerCertificate = true,
            MultipleActiveResultSets = true,
        };
        options.UseSqlServer(builder.ConnectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new DirectAgentEntityTypeConfiguration().Configure(modelBuilder.Entity<DirectAgent>());
        new HubAgentEntityTypeConfiguration().Configure(modelBuilder.Entity<HubAgent>());
        new MortgageAgentEntityTypeConfiguration().Configure(modelBuilder.Entity<MortgageAgent>());
    }    
}