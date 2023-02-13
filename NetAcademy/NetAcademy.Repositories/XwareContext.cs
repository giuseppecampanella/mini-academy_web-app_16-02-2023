using Microsoft.EntityFrameworkCore;
using NetAcademy.Repositories.SqlModels;

namespace NetAcademy.Repositories;

public class XwareContext : DbContext
{
    private readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=NetAcademy_16-02-2023;Trusted_Connection=True;";//connection string di default se non viene passaa da altrove


    internal DbSet<Concession> Concessions { get; set; }
    internal DbSet<Country> Countries { get; set; }
    internal DbSet<CountryConcession> CountryConcessions { get; set; }

    public XwareContext() { }

    public XwareContext(string connStr) : this()
    {
        connectionString = connStr;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountryConcession>().ToTable("CountryConcession");
        modelBuilder.Entity<Country>().ToTable("Country");
        modelBuilder.Entity<Concession>().ToTable("Concession");

        // create a compound key
        modelBuilder.Entity<CountryConcession>()
            .HasKey(sc => new { sc.CountryId, sc.ConcessionId });

        modelBuilder.Entity<CountryConcession>()
            .HasOne(ecc => ecc.Country)
            .WithMany(ec => ec.Concessions)
            .HasForeignKey(ecc => ecc.CountryId);

        modelBuilder.Entity<CountryConcession>()
            .HasOne(ecc => ecc.Concession)
            .WithOne(c => c.Country);

        modelBuilder.Entity<Country>()
            .HasMany(ec => ec.Concessions)
            .WithOne(c => c.Country);

        modelBuilder.Entity<Concession>()
            .HasOne(c => c.Country)
            .WithOne(ec => ec.Concession);
    }
}