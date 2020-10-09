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

        public BookController()
        {
            _bookRepo = new BookRepository();
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

        public ViewResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddBook(BookModel bookModel)
        {
            return View();
        }

        // http://localhost:5000/book/searchbooks?bookName=MVCBook&authorName=Author
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepo.SearchBooks(bookName, authorName);
        }
    }
}