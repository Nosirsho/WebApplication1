using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess.Configurations;
using WebApplication1.Models;

namespace WebApplication1.DataAccess;

public class CafeDbContext: DbContext
{
    private readonly IConfiguration _configuration;

    public CafeDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //var connectionString = _configuration.GetConnectionString("DefaultConnection");
        var connectionString = "Host=localhost;Port=5433;Database=cafe;Username=postgres;Password=postgres;";
        optionsBuilder.UseNpgsql(connectionString);
        optionsBuilder.LogTo(System.Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlaceConfiguration());
        modelBuilder.ApplyConfiguration(new PlaceCategoryConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<PlaceCategoty> PlaceCategoties =>Set<PlaceCategoty>();
    public DbSet<Place> Places =>Set<Place>();
}