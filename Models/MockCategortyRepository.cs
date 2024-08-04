
namespace Kookis.Models
{
    public class MockCategortyRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category {CategoryId = 1, CategoryName = "Fruit pies", Description=
                    "All-fruity pies"},
                new Category {CategoryId = 2, CategoryName = "Cheese cakes", Description=
                    "Cheesy all the way"},
                new Category {CategoryId = 3, CategoryName ="Seasonal", Description=
                    "Get in the mood for a seasonal pie"}
            };


    }
}
