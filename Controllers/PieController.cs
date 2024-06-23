using Kookis.Models;
using Kookis.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kookis.Controllers
{
    public class PieController : Controller
    {
       private readonly IPieRepository _pieRepository;
       private readonly ICategoryRepsitory _categoryRepository;

       public PieController (IPieRepository pieRepository, ICategoryRepsitory categoryRepository) 
        { 
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            
        }

        public IActionResult List()   
        {
            PiesListViewModel piesListViewModel = new PiesListViewModel
              (_pieRepository.AllPies,"Cheese cake");
         return View(piesListViewModel);

        }

        public IActionResult Details(int id) 
        { 
            var pie = _pieRepository.GetPieById(id);
            
           

            return View(pie);
        }



    }
}




