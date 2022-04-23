using BookStoreWeb.Models.DataContext;


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
            var books = _contextBook.Books.ToList();
            return books;
        }


    }
}
