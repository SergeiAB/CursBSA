using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWeb.DataContext
{
    public class ContextBook:DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Stock> Stocks { get; set; } = null!;

        public ContextBook(DbContextOptions<ContextBook> options):base(options)
        {
           Database.EnsureCreated();
        }

        
    }

    public class Book
    {
        
        public int BookId { get; set; }//id книги
        [Required]
        public string Img { get; set; }//путь к изображению книги
        [Required]
        public string Title { get; set; }//название книги
        [Required]
        public string Annotation { get; set; }//описание книги
        public bool IsFavorite { get; set; } //лидер продаж
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Stock> Stocks { get; set; }

        public Book()
        {
            this.Genres = new HashSet<Genre>();
            this.Authors = new HashSet<Author>();
            this.Stocks = new HashSet<Stock>();
        }
    }

    public class Genre
    {
        public int GenreId { get; set; }// id категории
        [Required]
        public string Name { get; set; } //тип жанра:фантастика худ. литература и тд
        public ICollection<Book> Books { get; set; }// список книг текущей категории

        public Genre() 
        {
            Books = new HashSet<Book>();
        }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Surname { get; set; }
        [Required]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Firstname { get; set; }
        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string? Secondname { get; set; }
        [Required]
        public string Biography { get; set; }
        public bool IsReader { get; set; }
        public ICollection<Book> Books { get; set; }

        public Author()
        {
            this.Books = new HashSet<Book>();
        }
        
    }

    public class Stock
    {
       
        public int StockId { get; set; }
       
        public int CountBook { get; set; }

       
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
       
    }

}
