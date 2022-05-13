namespace BookStoreWeb.Models.DBmodel
{
    public class Genre
    {
        public int GenreId { get; set; }// id категории
        public string Name { get; set; } //тип жанра:фантастика худ. литература и тд
        public ICollection<Book> Books { get; set; }// список книг текущей категории
    }
}
