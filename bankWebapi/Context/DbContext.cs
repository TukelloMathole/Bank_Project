using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using bank_App.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

public class AppDbContext : DbContext
{
    public DbSet<UserPersonalInformation> UserPersonalInformation { get; set; }
    public DbSet<UserContactInformation> UserContactInformation { get; set; }
    public DbSet<SecurityAuthentication> SecurityAuthentication { get; set; }
    public DbSet<Account_Table> Account_Table { get; set; }
    public DbSet<FinancialInformation> FinancialInformation { get; set; }
    public DbSet<TransactionTable> TransactionTable { get; set; }

    public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

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
        optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserContactInformation>()
           .HasKey(u => u.Customer_ID);
        modelBuilder.Entity<Account_Table>()
           .HasKey(u => u.Account_ID);
        modelBuilder.Entity<SecurityAuthentication>()
           .HasKey(u => u.User_ID);
        modelBuilder.Entity<FinancialInformation>()
            .HasKey(u => u.ID);
        modelBuilder.Entity<TransactionTable>()
            .HasKey(u => u.Transaction_ID);
    }
}
