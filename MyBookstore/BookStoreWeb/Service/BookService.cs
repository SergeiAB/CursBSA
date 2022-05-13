
using BookStoreWeb.DataContext;
using BookStoreWeb.MapingDB;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Service
{
    public class BookService:IBookService
    {
        private ContextBook _contextBook;

        public BookService(ContextBook contextBook)
        {
            _contextBook = contextBook;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var books = _contextBook.Books.Include(a=>a.Authors)
                                          .Include(g => g.Genres)
                                          .Include(p=>p.Stocks)
                                          .ToList();
            return books;
        }

        public void CreatBook(Book book, Author author, Stock stock, Genre genre)
        {
            book.Stocks.Add(stock);
            book.Authors.Add(author);
            author.Books.Add(book);
            book.Genres.Add(genre);
            genre.Books.Add(book);
            _contextBook.Authors.Add(author);
            _contextBook.Books.Add(book);
            _contextBook.Genres.Add(genre);
            _contextBook.Stocks.Add(stock);
            _contextBook.SaveChanges();
        }

        
        
    }
}
