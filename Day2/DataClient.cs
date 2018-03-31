using System;
using DataAccessLib; 
namespace SampleConApp
{
    class DataClient
    {
        static void Main(string[] args)
        {
            try
            {
                var csv = @"E:\Programs\inTimeTraining\SampleConApp\Menu.csv";
                var com = new ConnectedComponent();
                com.UploadMenu(1,csv);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
