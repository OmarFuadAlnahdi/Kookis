namespace Kookis.Models
{
    public interface ICategoryRepsitory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
