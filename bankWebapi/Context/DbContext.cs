using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using bank_App.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

public class AppDbContext : DbContext
{
    public DbSet<UserPersonalInformation> UserPersonalInformation { get; set; }
    /*public DbSet<UserContactInformation> UserContactInformation { get; set; }
    public DbSet<SecurityAuthentication> SecurityAuthentication { get; set; }
    public DbSet<Account_Table> Account_Table { get; set; }*/

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
        
    }
}
