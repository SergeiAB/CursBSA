
using BookStoreWeb.DataContext;

namespace BookStoreWeb.Service
{
    public interface IBookService
    {
        
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Genre> GetAllGenre(); 
        IEnumerable<Author> GetAllAutors();
        Book GetBook(int id);
        void CreatBook(Book book, int[] selectAuthor, int[] selectGenre, IFormFile uploadedFhoto);
        void DeleteBook(int id);
        void CreatGenre(Genre genre);
        void CreateAuthor(Author author);
        void EditBook(int id, Book newBook, int[] selGenres, int[] delGenres, IFormFile editFhoto, int[] selAuthors, int[] delAuthors);
    }
}
