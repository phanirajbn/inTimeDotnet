using System;
using System.IO;
using DataAccessLib;
namespace SampleConApp
{
    static class UIInteraction
    {
        public static int GetInteger(string question)
        {
            int result = 0;
            do
            {
                Console.WriteLine(question);
            } while (!int.TryParse(Console.ReadLine(), out result));
            return result;
        }

        public static DateTime GetDate(string question)
        {
            DateTime result;
            do
            {
                Console.WriteLine(question);
            } while (!DateTime.TryParse(Console.ReadLine(), out result));
            return result;
        }
        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
    class DllClient
    {
        static IDataComponent component = ComponentFactory.CreateComponent();
        static void Main(string[] args)
        {
            var fileName = args[0];
            bool @continue = true;
            string menu = new StreamReader(fileName).ReadToEnd();
            do
            {
                string choice = UIInteraction.GetString(menu);
                @continue = processMenu(choice);
            } while (@continue);
        }

        private static bool processMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    createEmp();
                    return true;
                case "2":
                    deleteEmp();
                    return true;
                case "3":
                    Console.WriteLine("Not implemented in this version");
                    return true;
                case "4":
                    displayRec();
                    return true;
                case "5":
                    displayAllRecs();
                    return true;
                default:
                    return false;
            }
        }

        private static void displayAllRecs()
        {
            var recs = component.FindEmployee(UIInteraction.GetString("Enter the Name to search"));
            foreach (var rec in recs)
                displayEmpInfo(rec);
        }

        private static void displayRec()
        {
            try
            {
                var id = UIInteraction.GetInteger("Enter the ID to search");
                var emp = component.FindEmployee(id);
                displayEmpInfo(emp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void displayEmpInfo(Employee emp)
        {
            Console.WriteLine("The Name is " + emp.EmployeeName);
            Console.WriteLine("The Address is " + emp.EmployeeAddress);
            Console.WriteLine("The Age is " + emp.Age);
        }
        private static void deleteEmp()
        {
            try
            {
                int id = UIInteraction.GetInteger("Enter an ID to delete");
                component.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void createEmp()
        {
            try
            {
                var emp = new Employee();
                emp.EmployeeID = UIInteraction.GetInteger("Enter the ID of the Employee");
                emp.EmployeeName = UIInteraction.GetString("Enter the Name");
                emp.EmployeeAddress = UIInteraction.GetString("Enter the Address");
                emp.EmployeeDateOfBirth = UIInteraction.GetDate("Enter the date of birth in the format of dd/MM/yyyy");
                component.AddNewEmployee(emp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}