using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore
{
    public class BookController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        private readonly BookRepository _bookRepo;

        public BookController(BookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        public ViewResult GetAllBooks()
        {
            Title = "All Books";
            var data = _bookRepo.GetAllBooks();
            return View(data);
        }

        public ViewResult GetBook(int id)
        {
            var book = _bookRepo.GetBook(id);
            return View(book);
        }

        public ViewResult AddBook(bool isSuccessful = false, int bookId = 0)
        {
            ViewBag.isSuccessful = isSuccessful;
            ViewBag.bookId = bookId;
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(BookModel bookModel)
        {
            int id = _bookRepo.AddBook(bookModel);
            if(id > 0)
            {
                return RedirectToAction("AddBook", new { isSuccessful=true, bookId = id});
            }
            return View();
        }

        // http://localhost:5000/book/searchbooks?bookName=MVCBook&authorName=Author
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepo.SearchBooks(bookName, authorName);
        }
    }
}