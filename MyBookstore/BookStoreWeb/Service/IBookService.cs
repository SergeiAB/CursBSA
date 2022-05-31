
using BookStoreWeb.DataContext;

namespace BookStoreWeb.Service
{
    public interface IBookService
    {
        
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Genre> GetAllGenre(); 
        IEnumerable<Author> GetAllAutors();
        void CreatBook(Book book, int[] selectAuthor, Stock stock, int[] selectGenre, IFormFile uploadedFhoto);
        void CreatGenre(Genre genre);
        void CreateAuthor(Author author);
    }
}
