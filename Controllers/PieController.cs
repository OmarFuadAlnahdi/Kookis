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

        //public IActionResult List()   
        //{
        //    PiesListViewModel piesListViewModel = new PiesListViewModel
        //      (_pieRepository.AllPies,"All Pies");
        // return View(piesListViewModel);
        //
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;

            string? currentCategory;

            if(string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else 
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName ==
                    category)
                       .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories
                    .FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View (new PiesListViewModel(pies, currentCategory));
        
        
        }

        public IActionResult Details(int id) 
        {
            var pie = _pieRepository.GetPieById(id);
            return View(pie);
        }



    }
}




