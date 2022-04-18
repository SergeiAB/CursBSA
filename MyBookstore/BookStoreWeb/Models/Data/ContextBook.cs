using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWeb.Models.Data
{
    public class ContextBook:DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Autor> Autors { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Stock> Stocks { get; set; } = null!;

        public ContextBook(DbContextOptions<ContextBook> options):base(options)
        {
           //Database.EnsureCreated();
        }

        
    }

    public class Book
    {
        public int Id { get; set; }//id книги
        public string Img { get; set; }//путь к изображению книги
        public string Title { get; set; }//название книги
        public string Autor { get; set; }//автор книги
        public string Annotation { get; set; }//описание книги
        public bool IsFavorite { get; set; } //лидер продаж
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Autor> Autors { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }// id категории
        public string Name { get; set; } //тип жанра:фантастика худ. литература и тд
        public ICollection<Book> Books { get; set; }// список книг текущей категории
    }

    public class Autor
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Biography { get; set; }
        public bool IsReader { get; set; }
        public ICollection <Book> Books { get; set; }
    }

    public class Stock
    {
        public int StockId { get; set; }
        public int CountBook { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public ICollection<Book> Books { get; set; }
    }

}
