using Microsoft.AspNetCore.Mvc;
using Kookis.Models;

namespace Kookis.Compponents
{

    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepsitory _categoryRepsitory;

        public CategoryMenu(ICategoryRepsitory categoryRepsitory)
        {
            _categoryRepsitory = categoryRepsitory;
        }
        public IViewComponentResult Invoke() 
        {
            var categories = _categoryRepsitory.AllCategories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
