
using BookStoreWeb.DataContext;

namespace BookStoreWeb.Service
{
    public interface IBookService
    {
        
        IEnumerable<Book> GetAllBooks();
        void CreatBook(Book book, Author author, Stock stock, Genre genre);
    }
}
