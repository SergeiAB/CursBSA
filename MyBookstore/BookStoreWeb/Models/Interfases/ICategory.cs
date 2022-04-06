using BookStoreWeb.Models.ModelData;

namespace BookStoreWeb.Models.Interfases
{
    public interface ICategory
    {
        IEnumerable<Category> GetCategories();
    }
}
