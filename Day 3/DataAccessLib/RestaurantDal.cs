using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLib
{
    public interface IRestaurantDal
    {
        bool ValidateUser(string username, string password);
        void RegisterUser(string name, string address, string email, long phoneNo, string username, string password);
        long RestaurantID { get; }
        void UploadMenu(DataTable table);
    }
    public class RestaurantDal : IRestaurantDal
    {
        public long RestaurantID
        {
            get;
            private set;
        }

        public void RegisterUser(string name, string address, string email, long phoneNo, string username, string password)
        {
            int regNo = 0;
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["myCon"].ConnectionString);
            SqlCommand sqlCmd = new SqlCommand("registerUser", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@address", address);
            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@no", phoneNo);
            sqlCmd.Parameters.AddWithValue("@username", username);
            sqlCmd.Parameters.AddWithValue("@pwd", password);
            sqlCmd.Parameters.AddWithValue("@regId", regNo);
            sqlCmd.Parameters[6].Direction = ParameterDirection.Output;
            try
            {
                sqlCon.Open();
                sqlCmd.ExecuteNonQuery();
                RestaurantID = Convert.ToInt64(sqlCmd.Parameters["@regId"].Value);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

        }

        public void UploadMenu(DataTable table)
        {
            if (RestaurantID <= 0)
                throw new Exception("Please login or register");
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["myCon"].ConnectionString);
                
            foreach(DataRow row in table.Rows)
            {
                var query = string.Format($"INSERT INTO MENUTABLE VALUES('{row[0]}','{row[1]}', {RestaurantID})");
                SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                sqlCmd.ExecuteNonQuery();
            }
            sqlcon.Close();
        }

        public bool ValidateUser(string username, string password)
        {
            DataSet ds = new DataSet("MyHotels");
            SqlDataAdapter sqlAda = new SqlDataAdapter("SELECT * FROM RESTAURANTTABLE", ConfigurationManager.ConnectionStrings["myCon"].ConnectionString);
            sqlAda.Fill(ds, "Hotels");
            foreach(DataRow row in ds.Tables["Hotels"].Rows)
            {
                if ((row["username"].ToString() == username) && (row["password"].ToString() == password))
                {
                    RestaurantID = Convert.ToInt64(row[0]);
                    return true;
                }
            }
            return false;            
        }
    }
}
