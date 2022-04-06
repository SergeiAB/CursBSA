using BookStoreWeb.Models.Interfases;
using BookStoreWeb.Models.ModelData;

namespace BookStoreWeb.Models.Service
{
    public class ServiceAllBook : IAllBooks
    {
        
        public IEnumerable<Book> BooksList
        {
            get => new List<Book>
            {       new Book
                    {
                        Id=1,
                        Title="Моя первая книга",
                        Autor="Остап Бендер",
                        Price=12.86m,
                        Img="",
                        Annotation="Полный бред Анотация на книгу",
                        Stock=5,
                        isFavorite=true,
                        CategoryId=1
                    },
                    new Book
                    {
                        Id=2,
                        Title="Вторая моя книга",
                        Autor="Я Сам Себе автор",
                        Price=20.97m,
                        Img="",
                        Annotation="Самая удачная книга Анотация на книгу",
                        Stock=15,
                        isFavorite=false,
                        CategoryId=2
                    },
                    new Book
                    {
                        Id=3,
                        Title="Где то третья книга",
                        Autor="Автор неизвестен",
                        Price=18.44m,
                        Img="",
                        Annotation="Апроксимация орлорлора Анотация на книгу",
                        Stock=8,
                        isFavorite=true,
                        CategoryId=3
                    },
                    new Book
                    {
                        Id=4,
                        Title="4 Название не придумал",
                        Autor="Тоже не придумал ",
                        Price=19.12m,
                        Img="",
                        Annotation="Анотация на книгу пмвавевавмм вмврвм",
                        Stock=2,
                        isFavorite=false,
                        CategoryId=4
                    },
                    new Book
                    {
                        Id=5,
                        Title="Пятая не моя книга",
                        Autor="Что вижу то пишу",
                        Price=19.12m,
                        Img="",
                        Annotation="Анотация на книгу лрлорлорол",
                        Stock=2,
                        isFavorite=true,
                        CategoryId=2
                    },

            };

            set => throw new NotImplementedException("Не реализованна set GetFavoritBook");
        }


        public IEnumerable<Book> GetFavoritBook
        {
            get => throw new NotImplementedException("Не реализованна GetFavoritBook");
            set => throw new NotImplementedException("Не реализованна GetFavoritBook");
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException("Не реализованна GetBook(int id)");
        }
    }
}
