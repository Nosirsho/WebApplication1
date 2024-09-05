using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DataAccess;

public class CafeDbContext: DbContext
{
    public CafeDbContext(DbContextOptions<CafeDbContext> options): base(options)
    {
        Database.EnsureCreated();
    }
    //
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
    // }
    //
    public DbSet<PlaceCategoty> PlaceCategoties { get; set; }
}