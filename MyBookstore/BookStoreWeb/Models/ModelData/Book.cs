namespace BookStoreWeb.Models.ModelData
{
    public class Book
    {
        public int Id { get; set; }//id книги
        public string Img { get; set; }//путь к изображению книги
        public string Title { get; set; }//название книги
        public string Autor { get; set; }//автор книги
        public string Annotation { get; set; }//описание книги
        public decimal Price { get; set; }// цена экземпляра
        public int Stock { get; set; }//количество на складе
        public bool isFavorite { get; set; } //лидер продаж
        public int CategoryId { get; set; }//id категории
        
    }
}
