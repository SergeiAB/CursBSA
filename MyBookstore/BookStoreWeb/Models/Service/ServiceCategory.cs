using BookStoreWeb.Models.Interfases;
using BookStoreWeb.Models.ModelData;

namespace BookStoreWeb.Models.Service
{
    public class ServiceCategory : ICategory
    {
        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category() { Name = "Фантастика",Id =1},
                new Category() { Name ="Классика",Id =2},
                new Category() { Name ="Бизнес",Id =3},
                new Category() { Name ="Поэзия",Id =4}
            };
        }
    }

}
