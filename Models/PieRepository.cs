using Microsoft.EntityFrameworkCore;

namespace Kookis.Models;

public class PieRepository: IPieRepository
{
    private readonly KookisDbContext _kookisPieShopDbContext;

    public PieRepository(KookisDbContext kookisDbContext) 
    { 
        _kookisPieShopDbContext = kookisDbContext;
    }

    public IEnumerable<Pie> AllPies
    {
        get
        {
            return _kookisPieShopDbContext.Pies.Include(c => c.Category);
        }
    }

    public IEnumerable<Pie> PiesOfTheWeek
    {
        get 
        {
            return _kookisPieShopDbContext.Pies.Include(c => c.Category).Where
                (p => p.IsPieOfTheWeek);
        }
    }

    public Pie? GetPieById(int pieId)
    {
        return _kookisPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
    }
}
