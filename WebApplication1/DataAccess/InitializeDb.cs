using WebApplication1.Models;

namespace WebApplication1.DataAccess;

public class InitializeDb
{
    private readonly CafeDbContext _context;

    public InitializeDb(CafeDbContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        PlaceCategoty placeCategoty1 = new ("Зал", "Зал");
        PlaceCategoty placeCategoty2 = new ("Кабина", "Кабина");
        PlaceCategoty placeCategoty3 = new ("VIP", "VIP");
        
        _context.PlaceCategoties.AddRange(placeCategoty1, placeCategoty2, placeCategoty3);
        _context.SaveChanges();
        
        Place place1 = new ("Кабина 1", placeCategoty1.Id, "qsqs");
        Place place2 = new ("Кабина 2", placeCategoty1.Id, "qsq");
        Place place3 = new ("Кабина 3", placeCategoty1.Id, "qsqsq");
        
        _context.Places.AddRange(place1, place2, place3);
        _context.SaveChanges();
    }
}