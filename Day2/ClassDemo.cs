using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//A Class is a UDT used to have a data type which has both the data and functions in it.  A Class is designed based on the principles of OOP: SOLID Principles...
/*SOLID Principles:
 * Single Responsibility Principle: A Class should do only one task
 * Open Close Principle
 * Luskov's Substitution Principle
 * Interface Segregation Principle
 * Dependency Principle
 */
namespace SampleConApp
{
    namespace UI
    {
        using System.IO;
        using Entities;
        using DataLayer;
        //static class has only static functions and U cannot instantiate them....
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
        class ClassDemo
        {
            static IDataComponent component = new ListDataComponent();
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
                var recs = component.FindEmployee(UIInteraction.GetString("Enter the name or part of the Name to search"));
                foreach(var emp in recs)
                {
                    displayEmpInfo(emp);
                    Console.WriteLine();
                }
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
                catch(Exception ex)
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

    namespace Entities
    {
        //Entities represent data only...

        /// <summary>
        /// Represents the Employee Component of Our Application..
        /// </summary>
        class Employee
        {
            /// <summary>
            /// Gets or sets the ID of the Employee
            /// </summary>
            public int EmployeeID { get; set; }
            /// <summary>
            /// Gets or Sets the name of the Employee
            /// </summary>
            public string EmployeeName { get; set; }
            public string EmployeeAddress { get; set; }
            public DateTime EmployeeDateOfBirth { get; set; }
            /// <summary>
            /// Gets the Age of the Employee. Gets the value after the EmployeeDateOfBirth is set
            /// </summary>
            public int Age
            {
                get
                {
                    var current = DateTime.Now;
                    var span = current - EmployeeDateOfBirth;
                    return span.Days / 365;
                }
            }
        }
    }

    namespace DataLayer
    {
        using Entities;
        //When U intend to allow  UR derived classes to modify UR functions, then U should mark the methods as virtual methods. Only virtual methods can be modified in the derived classes.
        class DataComponent
        {
            Employee[] _data = new Employee[100];

            public virtual void AddNewEmployee(Employee emp)
            {
                for (int i = 0; i < _data.Length; i++)
                {
                    if(_data[i] == null)
                    {
                        _data[i] = new Employee
                        {
                            EmployeeID = emp.EmployeeID,
                            EmployeeAddress = emp.EmployeeAddress,
                            EmployeeName =  emp.EmployeeName,
                            EmployeeDateOfBirth = emp.EmployeeDateOfBirth
                        };
                        return;
                    }
                }
                throw new Exception("Cannot add new record");
                //Throw an exception if all the records are filled, saying no more employees could be added
            }

            public virtual void DeleteEmployee(int id)
            {
                for (int i = 0; i < _data.Length; i++)
                {
                    if((_data[i] != null) && (_data[i].EmployeeID == id))
                    {
                        _data[i] = null;
                        return;
                    }
                }
                throw new Exception("No Employee found to delete");
            }

            public virtual Employee FindEmployee(string name)
            {
                foreach(var emp in _data)
                {
                    if ((emp != null) && (emp.EmployeeName == name))
                        return emp;
                }
                throw new Exception("Employee not found");
            }
            public virtual void UpdateEmployee(Employee emp)
            {
                throw new NotImplementedException("Not implemented by the trainer");
            }
        }
    }
}
