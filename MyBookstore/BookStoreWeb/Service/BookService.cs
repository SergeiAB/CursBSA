
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

        public void CreatBook(Book book, int[] selectAutor, Stock stock, int[] selectGenre)
        {
            if (selectGenre != null)
            {
                foreach(var genre in _contextBook.Genres.Where(x => selectGenre.Contains(x.GenreId)))
                {
                    book.Genres.Add(genre);
                }
            }
            if(selectAutor != null)
            {
                foreach(var autor in _contextBook.Authors.Where(x => selectAutor.Contains(x.AuthorId)))
                {
                    book.Authors.Add(autor);
                }
            }

            //book.Authors.Add(author);
            //author.Books.Add(book);
            //book.Genres.Add(genre);
            //genre.Books.Add(book);
            book.Stocks.Add(stock);
            //_contextBook.Authors.Add(author);
            _contextBook.Books.Add(book);
            //_contextBook.Genres.Add(genre);
            _contextBook.Stocks.Add(stock);
            _contextBook.SaveChanges();
        }

        public IEnumerable<Genre> GetAllGenre()
        {
            var genre =_contextBook.Genres.ToList();
            return genre;
        }

        public IEnumerable<Author> GetAllAutors()
        {
            var autor = _contextBook.Authors.ToList();
            return autor;
        }

        public void CreatGenre(Genre genre)
        {
            _contextBook.Genres.Add(genre);
            _contextBook.SaveChanges();
        }
        public void DeleteGenre(int[] selectGenre)
        {
            if (selectGenre != null)
            {
                foreach (var genre in _contextBook.Genres.Where(x => selectGenre.Contains(x.GenreId)))
                {
                    _contextBook.Genres.Remove(genre);
                }
                _contextBook.SaveChanges();
            }
        }

        public void CreateAuthor(Author author)
        {
            _contextBook.Authors.Add(author);
            _contextBook.SaveChanges();
        }
    }
}
