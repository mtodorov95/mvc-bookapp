using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            // pass data to the view
            ViewBag.Title = "Viewbag title";
            return View();
        }

        public ViewResult AboutUs()
        {
            // Returns the view with the same name as the method
            return View();
        }

        public ViewResult ContactUs()
        {
            // Returns the view with the same name as the method
            return View();
        }
    }
}