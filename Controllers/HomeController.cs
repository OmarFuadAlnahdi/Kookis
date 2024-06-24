using Kookis.Models;
using Kookis.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kookis.Controllers
{
    public class HomeController : Controller
    {

        public readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository) 
        {
            _pieRepository = pieRepository;
        }



        public IActionResult Index()
        {
            var piesOFTheWeek = _pieRepository.PiesOfTheWeek;
            var homeViewModel = new HomeViewModel(piesOFTheWeek);
            return View(homeViewModel);
        
        }
    }
}
