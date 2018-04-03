using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
namespace SampleMvcApp.Controllers
{
    public class HotelController : Controller
    {
        //Represents the DASH BOARD for Restaurant....
        public ActionResult Home()
        {
            var context = new inTimeDatabaseEntities();
            var hotels = context.RestaurantTables.ToList();
            return View(hotels);
        }
        // GET: Hotel
        public PartialViewResult Register()
        {
            RestaurantTable hotel = new RestaurantTable();
            hotel.Address = "Bangalore";//Initialization could be done to the Model and inject it to the Http Get....
            return PartialView(hotel);//Similar to Usercontrols of ASPX pages...
        }

        [HttpPost]
        public ActionResult Register(RestaurantTable model)
        {
            var dbContext = new inTimeDatabaseEntities();
            dbContext.RestaurantTables.Add(model);
            dbContext.SaveChanges();
            return RedirectToAction("Home");
        }
    }
}