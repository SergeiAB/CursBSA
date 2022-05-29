using BookStoreWeb.DataContext;
using BookStoreWeb.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        // GET: BookController
        public ActionResult Index()
        {
            var books = bookService.GetAllBooks();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var genre = bookService.GetAllGenre();
            var author = bookService.GetAllAutors();
            ViewBag.Genre = genre;
            ViewBag.Author = author;
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Book book, int[] selectAuthor,Stock stock, int[] selectGenre)
        {
            try
            {
                bookService.CreatBook(book, selectAuthor, stock, selectGenre);

                return RedirectToAction("index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateGenre(Genre genre)
        {
            try
            {
               bookService.CreatGenre(genre);
               return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult CreateGenre()
        {
            
            return View();
        }
        
        [HttpGet]
        public ActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAuthor(Author author)
        {
            try
            {
                bookService.CreateAuthor(author);
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }

        }
    }
}
