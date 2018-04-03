using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    //Methods  of UR Controller are called as Actions...
    public class HomeController : Controller
    {
        //public string Index()
        //{
        //    return "Hello MVC";
        //}
        public ViewResult Index()
        {
            ViewBag.Title = "Hello MVC";
            return View();//string is to repesent the View, models are objects..
        }
    }
}