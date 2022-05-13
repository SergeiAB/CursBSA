namespace BookStoreWeb.Models.DBmodel
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Biography { get; set; }
        public bool IsReader { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
