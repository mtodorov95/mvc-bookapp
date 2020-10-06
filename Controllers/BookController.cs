using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore
{
    public class BookController : Controller
    {
        // http://localhost:5000/book/getallbooks
        public string GetAllBooks()
        {
            return "All books in storage";
        }

        // Pass params
        // http://localhost:5000/book/getbook/4
        public string GetBook(int id)
        {
            return $"Book {id}";
        }

        // http://localhost:5000/book/searchbooks?bookName=MVCBook&authorName=Author
        public string SearchBooks(string bookName, string authorName)
        {
            return $"A book named {bookName} by {authorName}";
        }
    }
}