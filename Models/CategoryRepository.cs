namespace Kookis.Models
{
    public class CategoryRepository : ICategoryRepsitory
    {
        private readonly KookisDbContext _kookisDbContext;
        
        public CategoryRepository (KookisDbContext kookisDbContext) 
        {
            _kookisDbContext = kookisDbContext;
        }

        public IEnumerable<Category> AllCategories => _kookisDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
