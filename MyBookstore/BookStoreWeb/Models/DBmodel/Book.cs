namespace BookStoreWeb.Models.DBmodel
{
    public class Book
    {

        public int BookId { get; set; }//id книги
        public string Img { get; set; }//путь к изображению книги
        public string Title { get; set; }//название книги
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
}
