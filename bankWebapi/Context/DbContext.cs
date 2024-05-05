using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using static BankAccountRegistrationModel;
using bank_App.Model;

public class AppDbContext : DbContext
{
    public DbSet<BankAccountRegistration> BankAccountRegistration { get; set; }
    public DbSet<AccountInfo> AccountInfo { get; set; }

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
        modelBuilder.Entity<BankAccountRegistration>().HasKey(p => p.ID);
        modelBuilder.Entity<AccountInfo>().HasKey(p => p.Account_ID);
    }
    public interface IAppDbContext : IDisposable
    {
        IQueryable<BankAccountRegistration> BankAccountRegistration { get; }
    }

}
