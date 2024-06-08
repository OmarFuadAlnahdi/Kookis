
namespace Kookis.Models
{
    public class MockCategortyRepository : ICategoryRepsitory
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category {CategotyId = 1, CategoryName = "Fruit pies", Description=
                    "All-fruity pies"},
                new Category {CategotyId = 2, CategoryName = "Cheese cakes", Description=
                    "Cheesy all the way"},
                new Category {CategotyId = 3, CategoryName ="Seasonal", Description=
                    "Get in the mood for a seasonal pie"}
            };


    }
}
