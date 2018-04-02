using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib
{
    public interface IRestaurant
    {
        void RegisterRestaurant(string name, string address, long contactNo);
        void UpdateRestaurant(int id, string name, string address, long contactNo);
        void UploadMenu(int restaurantID, string fileName);
    }
}
