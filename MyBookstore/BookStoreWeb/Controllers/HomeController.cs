using BookStoreWeb.Models;
using BookStoreWeb.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStoreWeb.Controllers
{
    
    public class HomeController : Controller
    {
       
        private readonly IBookService _bookService;
       
        public HomeController(IBookService bookService)
        {
           
            _bookService = bookService;
           
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();

            
            return View(books);
        }

        [Authorize(Roles = "user, admin")]
        public IActionResult ShowBook(int id)
        {
            var book = _bookService.GetBook(id);
            return View(book);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "user")]
        public IActionResult BuyBook()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult ListBookForAdmin()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}