
using BookStoreWeb.DataContext;
using BookStoreWeb.MapingDB;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Service
{
    public class BookService:IBookService
    {
        private ContextBook _contextBook;
        private IWebHostEnvironment _appEnvironment;

        public BookService(ContextBook contextBook, IWebHostEnvironment appEnvironment)
        {
            _contextBook = contextBook;
            _appEnvironment=appEnvironment;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var books = _contextBook.Books.OrderBy(x=>x.Title).Include(a=>a.Authors)
                                          .Include(g => g.Genres)
                                          .ToList();
            return books;
        }

        public void CreatBook(Book book, int[] selectAutor, int[] selectGenre, IFormFile uploadedFhoto)
        {
           
            book.Img = AddFile(uploadedFhoto, book);

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

            
            _contextBook.Books.Add(book);
            _contextBook.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book=_contextBook.Books.Where(x=>x.BookId == id).FirstOrDefault();
            if (book != null)
            {
                var path =_appEnvironment.ContentRootPath + book.Img;
                try
                {
                    _contextBook.Books.Remove(book);
                    _contextBook.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
                File.Delete(path);

            }
            
                
        }

        public IEnumerable<Genre> GetAllGenre()
        {
            var genre =_contextBook.Genres.OrderBy(p => p.Name).ToList();
            return genre;
        }

        public IEnumerable<Author> GetAllAutors()
        {
            var autor = _contextBook.Authors.OrderBy(p => p.Surname).ThenBy(u => u.Firstname).ToList();
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

        private  string AddFile(IFormFile uploadedFile, Book book)
        {

            if (uploadedFile != null)
            {
                string nameBook = book.Title.Trim().Replace(' ','_');
                var num= uploadedFile.FileName.IndexOf('.');
                var typeFile = uploadedFile.FileName.Substring(num);
                // путь к папке Images
               // string path = "/Images/" + uploadedFile.FileName;
                string path = "/Images/" + Guid.NewGuid().ToString()+"_"+nameBook+typeFile;

                // сохраняем файл в папку Images в каталоге BookStoreWeb
                using (var fileStream = new FileStream(_appEnvironment.ContentRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
               
                return path;
            }
            else
            {
                return string.Empty;
            }
            
        }

        public Book GetBook(int id)
        {
            var book = _contextBook.Books.Where(x => x.BookId == id).Include(a => a.Authors)
                                          .Include(g => g.Genres).FirstOrDefault();
                                        
            if (book != null)
            {
                return book;
            }
            else
            {
                throw new ArgumentNullException("В списке такой книги нет");
            }
            
            
        }

        public void deleteAuthorForBook(int bookId, int authorId)
        {
            var book = _contextBook.Books.Where(x => x.BookId == bookId).Include(a => a.Authors)
                                          .FirstOrDefault();
            var author=book.Authors.First(x=>x.AuthorId==authorId);
            book.Authors.Remove(author);
            _contextBook.SaveChanges();
        }
        public void EditBook(int id, Book newBook, int[] selGenres, int[] delGenres, IFormFile editFhoto, int[] selAuthors, int[] delAuthors)
        {
            
            if(newBook != null)
            {
                string img;
                if(editFhoto != null)
                {
                    var oldPath = _appEnvironment.ContentRootPath + newBook.Img;
                    img = AddFile(editFhoto,newBook);
                    File.Delete(oldPath);
                }
                else
                {
                    img = newBook.Img;
                }
                var book = GetBook(id);

                book.Img = img;
                book.Title = newBook.Title;
                book.Annotation = newBook.Annotation;
                book.IsFavorite = newBook.IsFavorite;
                book.CountBook = newBook.CountBook;
                book.Price = newBook.Price;

                if(selGenres.Length > 0)
                {
                    foreach (int i in selGenres)
                    {
                        var genre = _contextBook.Genres.Where(x => x.GenreId == i).FirstOrDefault();
                        book.Genres.Add(genre);
                    }

                }
                if (delGenres.Length > 0)
                {
                    foreach (int i in delGenres)
                    {
                        var genre = book.Genres.First(x=>x.GenreId==i);
                        book.Genres.Remove(genre);
                    }

                }

                if (selAuthors.Length > 0)
                {
                    foreach (int i in selAuthors)
                    {
                        var author = _contextBook.Authors.Where(x => x.AuthorId == i).FirstOrDefault();
                        book.Authors.Add(author);
                    }

                }
                if (delAuthors.Length > 0)
                {
                    foreach (int i in delAuthors)
                    {
                        var author = book.Authors.First(x => x.AuthorId == i);
                        book.Authors.Remove(author);
                    }

                }
                _contextBook.SaveChanges();
            }
        }
    }
}
