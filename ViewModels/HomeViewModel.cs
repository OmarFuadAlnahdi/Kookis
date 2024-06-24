using Kookis.Models;

namespace Kookis.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable <Pie> PiesOfTheWeek { get; set;}

        public HomeViewModel(IEnumerable<Pie> piesOFTheWeek)
        {
            PiesOfTheWeek = piesOFTheWeek;
        }
    }
}
