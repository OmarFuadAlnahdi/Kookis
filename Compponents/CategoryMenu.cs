using Microsoft.AspNetCore.Mvc;
using Kookis.Models;

namespace Kookis.Compponents
{

    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepsitory;

        public CategoryMenu(ICategoryRepository categoryRepsitory)
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
