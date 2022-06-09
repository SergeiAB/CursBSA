using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWeb.DataContext
{
    public class ContextBook : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        public ContextBook(DbContextOptions<ContextBook> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            string adminRoleName = "admin";
            string userRoleName = "user";
            string traderRoleName = "trader";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";
            string adminPhone = "+375(29)1234567";
            string adminName="Admin";

            string traderEmail = "trader@mail.ru";
            string traderPassword = "654321";
            string traderPhone = "+375(29)1234567";
            string traderName="Trader";
            // добавляем роли
            Role adminRole = new Role { Id = 1, RoleName = adminRoleName };
            Role userRole = new Role { Id = 2, RoleName = userRoleName };
            Role traderRole = new Role { Id = 3, RoleName = traderRoleName };

            User adminUser = new User { UserId = 1, Email = adminEmail, UserName=adminName, Phone=adminPhone, Password = adminPassword, RoleId = adminRole.Id };
            User traderUser = new User { UserId = 2, Email = traderEmail, UserName=traderName,Phone=traderPhone, Password = traderPassword, RoleId = traderRole.Id };
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole,traderRole });
            
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, traderUser});
           

            modelBuilder.Entity<Book>().Property(p => p.Price).HasPrecision(6, 2);

            base.OnModelCreating(modelBuilder);


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
        public int CountBook { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Author> Authors { get; set; }


        public Book()
        {
            this.Genres = new HashSet<Genre>();
            this.Authors = new HashSet<Author>();

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

    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }

    }
}

