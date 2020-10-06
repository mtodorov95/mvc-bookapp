using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore
{
    public class BookController : Controller
    {

        private readonly BookRepository _bookRepo;

        public BookController()
        {
            _bookRepo = new BookRepository();
        }


        // http://localhost:5000/book/getallbooks
        public ViewResult GetAllBooks()
        {
            var data = _bookRepo.GetAllBooks();
            return View();
        }

        // Pass params
        // http://localhost:5000/book/getbook/4
        public BookModel GetBook(int id)
        {
            return _bookRepo.GetBook(id);
        }

        // http://localhost:5000/book/searchbooks?bookName=MVCBook&authorName=Author
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepo.SearchBooks(bookName, authorName);
        }
    }
}