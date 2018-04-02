using System;
using System.Data.SqlClient;
using System.IO;
namespace DataAccessLib
{
    public class ConnectedComponent : IRestaurant
    {
        const string STRCONNECTION = "Data Source=.;Initial Catalog=inTimeDatabase;Integrated Security=True";
        const string STRINSERT = "INSERT INTO RESTAURANTTABLE VALUES(@name, @addrss, @contact)";
        const string STRUPDATE = "UPDATE RESTAURANTTABLE SET Name = @name, Address = @address, ContactNo = @contact WHERE RESTAURANTID = @id";
        public void RegisterRestaurant(string name, string address, long contactNo)
        {
//            var query = string.Format($"INSERT INTO RESTAURANTTABLE VALUES('{name}', '{address}', {contactNo})");
            //ConnectionString is a string that contain info about the database connectivity that includes Servername, Database name, credentials...
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            SqlCommand sqlCmd = new SqlCommand(STRINSERT, sqlCon);
            //When ever U want to provide data from external source to UR Query, U could do so using parameters.
            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@addrss", address);
            sqlCmd.Parameters.AddWithValue("@contact", contactNo);
            try
            {
                sqlCon.Open();
                sqlCmd.ExecuteNonQuery();//TO execute NON SELECT SQL statements
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

        public void UpdateRestaurant(int id, string name, string address, long contactNo)
        {
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            SqlCommand sqlCmd = new SqlCommand(STRUPDATE, sqlCon);
            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@address", address);
            sqlCmd.Parameters.AddWithValue("@contact", contactNo);
            sqlCmd.Parameters.AddWithValue("@id", id);
            try
            {
                sqlCon.Open();
                sqlCmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public void UploadMenu(int restaurantID, string fileName)
        {
            //Create the Connection
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            StreamReader reader = new StreamReader(fileName);
            sqlCon.Open();
            while (!reader.EndOfStream)
            {
                //Read the line
                string line = reader.ReadLine();
                //split the line as per the seperator(,)
                var values = line.Split(',');
                var query = string.Format($"INSERT INTO MENUTABLE VALUES('{values[0]}','{values[1]}', {restaurantID})");
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                //generate the Sql Statement for the Insertion...
                //create the command object...
                //execute the query...
            }
            sqlCon.Close();
        }
    }
}
