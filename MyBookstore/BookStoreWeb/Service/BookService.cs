
using BookStoreWeb.DataContext;
using BookStoreWeb.MapingDB;

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
            var books = _contextBook.Books;
            return books;
        }

        public void CreatBook(Book book, Author author, Stock stock)
        {
            book.Stocks.Add(stock);
            book.Authors.Add(author);
            author.Books.Add(book);
            _contextBook.Authors.Add(author);
            _contextBook.Books.Add(book);
            _contextBook.SaveChanges();
        }

        
        
    }
}
