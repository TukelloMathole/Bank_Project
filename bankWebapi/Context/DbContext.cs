using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using bank_App.Model;

public class AppDbContext : DbContext
{
    public DbSet<UserPersonalInformation> UserPersonalInformation { get; set; }
    public DbSet<UserContactInformation> UserContactInformation { get; set; }
    public DbSet<Accounts> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserPersonalInformation>().HasKey(p => p.ID);
        modelBuilder.Entity<UserContactInformation>().HasKey(p => p.Customer_ID);
        modelBuilder.Entity<Accounts>().HasKey(p => p.Account_ID);
    }
    public interface IAppDbContext : IDisposable
    {
        IQueryable<UserPersonalInformation> UserPersonalInformation { get; }
    }

}
