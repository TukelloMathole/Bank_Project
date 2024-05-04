using Microsoft.EntityFrameworkCore;
using static BankAccountRegistrationModel;

public class AppDbContext : DbContext
{
    public DbSet<PersonalInfo> PersonalInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure your connection string here
        optionsBuilder.UseSqlServer("DefaultConnection");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Optionally, you can configure model constraints, relationships, etc. here
        // For example:
        modelBuilder.Entity<PersonalInfo>().HasKey(p => p.IDNumber);
    }
}
