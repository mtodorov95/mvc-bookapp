using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        public ViewResult Index()
        {
            Title = "Home";
            // pass data to the view
            ViewBag.Title = "Viewbag title";
            return View();
        }

        public ViewResult AboutUs()
        {
            Title = "About";
            // Returns the view with the same name as the method
            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "Contacts";
            // Returns the view with the same name as the method
            return View();
        }
    }
}