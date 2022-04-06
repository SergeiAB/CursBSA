using BookStoreWeb.Models.ModelData;

namespace BookStoreWeb.Models.Interfases
{
    public interface IAllBooks
    {
        Book GetBook(int id);
        IEnumerable<Book> BooksList { get;}
        IEnumerable<Book> GetFavoritBook { get; set; }

    }
}
