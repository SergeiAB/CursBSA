﻿using BookStoreWeb.DataContext;
using BookStoreWeb.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;
        IWebHostEnvironment _appEnvironment;

        public BookController(IBookService bookService, IWebHostEnvironment appEnvironment)
        {
            this.bookService = bookService;
            _appEnvironment = appEnvironment;
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
        public ActionResult Create(Book book, int[] selectAuthor, int[] selectGenre, IFormFile uploadedFhoto)
        {
            try
            {
                bookService.CreatBook(book, selectAuthor, selectGenre, uploadedFhoto);

                return RedirectToAction("index");
                
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditBook(int id)
        {
            ViewBag.Genre = bookService.GetAllGenre();
            ViewBag.Author = bookService.GetAllAutors();
            var book= bookService.GetBook(id);
            return View(book);
        }


        // POST: BookController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditBook(int id,Book newBook,int[] selGenres, int[] delGenres, IFormFile editFhoto, int[] selAuthors, int[] delAuthors)
        {
       
                bookService.EditBook(id, newBook,  selGenres, delGenres, editFhoto,selAuthors, delAuthors);
                return RedirectToAction("index");
 
        }

        // GET: BookController/Delete/5
        public ActionResult DeleteBook(int id)
        {
            bookService.DeleteBook(id);
            return RedirectToAction("index");
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

        public FileContentResult GetFile(int id)
        {
            
            string basePath = _appEnvironment.ContentRootPath;
            var book = bookService.GetAllBooks();
            var pathFoto=book.Where(x=>x.BookId==id).FirstOrDefault().Img;
            var type = "image/jpeg";
            string fullPath = $"{basePath}{pathFoto}";
            byte[]? bytes = System.IO.File.ReadAllBytes(fullPath);
            return File(bytes, type);
        }
    }
}
