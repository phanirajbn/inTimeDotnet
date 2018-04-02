using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SampleWebApp
{
    using SampleWebApp.Models;
    public class Global : System.Web.HttpApplication
    {
        //App_Start, App_end Session_Start, 
        protected void Application_Start(object sender, EventArgs e)
        {
            List<RestaurantEntity> _allRestaurants = new List<RestaurantEntity>();
            Dictionary<string, string> users = new Dictionary<string, string>();

            Application["Hotels"] = _allRestaurants;
            Application["Logins"] = users;
            //refer the Application state in ASP.NET.....
        }
    }
}