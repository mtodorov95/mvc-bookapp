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
            // Returns the view with the same name as the method
            return View();
        }
    }
}