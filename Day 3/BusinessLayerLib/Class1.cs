namespace BusinessLayerLib
{
    using BusinessLayer.Entities;
    using DataAccessLib;
    using System.Data;
    using System.IO;

    public class RestaurantBal
    {
        private IRestaurantDal dalComponent = new RestaurantDal();
        
        public long RestaurantID { get; private set; }
        public bool ValidateUser(string username, string pwd)
        {
            try
            {
                bool result = dalComponent.ValidateUser(username, pwd);
                if (result)
                    RestaurantID = dalComponent.RestaurantID;
                return result;
            }
            catch (System.Exception balEx)
            {
                throw new System.Exception("Error in Dal layer while validating", balEx);
            }
        }  

        public void RegisterUser(Restaurant hotel)
        {
            //perform all UR validations and business rules here.......
            try
            {
                dalComponent.RegisterUser(hotel.Name, hotel.Address, hotel.EmailAddress, hotel.PhoneNo, hotel.UserName, hotel.Password);
                RestaurantID = dalComponent.RestaurantID;
            }
            catch (System.Exception balEx)
            {
                throw new System.Exception("Error while registing the details in DAL", balEx);
            }
        }

        public void UploadMenu(string fileName)
        {
            try
            {
                DataTable table = new DataTable("Menu");
                table.Columns.Add(new DataColumn("ItemName", typeof(string)));
                table.Columns.Add(new DataColumn("ItemPrice", typeof(string)));
                StreamReader reader = new StreamReader(fileName);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    //split the line as per the seperator(,)
                    var values = line.Split(',');
                    var row = table.NewRow();
                    row[0] = values[0];
                    row[1] = values[1];
                    table.Rows.Add(row);
                }
                table.AcceptChanges();
                dalComponent.UploadMenu(table);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
namespace BusinessLayer.Entities
{
    /// <summary>
    /// Represents the Restaurant Entity
    /// </summary>
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long PhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}