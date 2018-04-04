using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLib.Entities;
using DataLib;
namespace SampleWebApi.Controllers
{
    public class HotelController : ApiController
    {
        public List<Hotel> GetAllHotels()
        {
            var com = new HotelComponent();
            return com.GetAllHotels();
        }

        public Hotel GetHotel(string id)
        {
            int _id = int.Parse(id);
            var com = new HotelComponent();
            return com.GetAllHotels().FirstOrDefault(h => h.ID == _id);
        }
    }
}
