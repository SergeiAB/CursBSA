

using BookStoreWeb.Models.DataContext;

namespace BookStoreWeb.Service
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
    }
}
