using Microsoft.EntityFrameworkCore;
using NetAcademy.Repositories.SqlModels;

namespace NetAcademy.Repositories;

public class XwareContext : DbContext
{
    private readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=NetAcademy_16-02-2023;Trusted_Connection=True;";//connection string di default se non viene passaa da altrove


    internal DbSet<Concession> Concessions { get; set; }
    internal DbSet<ExtCountry> ExtCountries { get; set; }
    internal DbSet<ExtCountryConcession> ExtCountryConcessions { get; set; }

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
        modelBuilder.Entity<ExtCountryConcession>().ToTable("ExtCountryConcession");
        modelBuilder.Entity<ExtCountry>().ToTable("ExtCountry");
        modelBuilder.Entity<Concession>().ToTable("Concession");

        // create a compound key
        modelBuilder.Entity<ExtCountryConcession>()
            .HasKey(sc => new { sc.CountryId, sc.ConcessionId });

        modelBuilder.Entity<ExtCountryConcession>()
            .HasOne(ecc => ecc.ExtCountry)
            .WithMany(ec => ec.Concessions)
            .HasForeignKey(ecc => ecc.CountryId);

        modelBuilder.Entity<ExtCountryConcession>()
            .HasOne(ecc => ecc.Concession)
            .WithOne(c => c.ExtCountry);

        modelBuilder.Entity<ExtCountry>()
            .HasMany(ec => ec.Concessions)
            .WithOne(c => c.ExtCountry);

        modelBuilder.Entity<Concession>()
            .HasOne(c => c.ExtCountry)
            .WithOne(ec => ec.Concession);
    }
}