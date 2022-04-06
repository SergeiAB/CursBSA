namespace BookStoreWeb.Models.ModelData
{
    public class Category
    {
        public int Id { get; set; }// id категории
        public string Name { get; set; } //тип жанра:фантастика худ. литература и тд
        public string Desc { get; set; }// описание жанра
        public List<Book> Books { get; set; }// список книг текущей категории
    }
}
