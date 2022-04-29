using BookStoreWeb.DataContext;

namespace BookStoreWeb.MapingDB
{
    public static class Maping
    {
        public static Models.DBmodel.Book Map(Book book)
        {
            var lis = book.Authors;
            var newBook = new Models.DBmodel.Book()
            {
                BookId = book.BookId,
                Title = book.Title,
                Annotation = book.Annotation,
                Img = book.Img,
                
            };

            return newBook;
        }
        public static IEnumerable<Models.DBmodel.Book> Map(IEnumerable<Book> book)
        {
            List<Models.DBmodel.Book> books = new();

            foreach (var bk in book)
            {
                books.Add(Map(bk));
            }
            return books;
        }

        internal static Book Map(Models.DBmodel.Book newBook)
        {
            throw new NotImplementedException();
        }
    }
}

