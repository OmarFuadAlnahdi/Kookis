using Kookis.Models;
namespace Kookis.ViewModels
{
    public class PiesListViewModel
    {
        public IEnumerable<Pie> Pies { get; }
        public string? CurrentCategory { get;}
        public string ForWho { get; }

        public PiesListViewModel (IEnumerable<Pie> pies, string? currentCategory,string forWho)
        {
            Pies = pies;
            CurrentCategory = currentCategory;
            ForWho = forWho;
        }
        
    }
}
