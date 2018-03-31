using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//if a class is marked as public, then its accessible across the projects(Assemblies). Obviously, people create classes in DLLs to make it accessible across the projects....
namespace DataAccessLib
{
    //Entities represent data only...

    /// <summary>
    /// Represents the Employee Component of Our Application..
    /// </summary>
    public class Employee
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
    public interface IDataComponent
    {
        void AddNewEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int empID);
        Employee FindEmployee(int id);
        Employee[] FindEmployee(string name);//Method overloading....
    }
    class ListDataComponent : IDataComponent
    {
        List<Employee> empList = new List<Employee>();
        public void AddNewEmployee(Employee emp)
        {
            empList.Add(emp);
        }

        public void DeleteEmployee(int empID)
        {
            var emp = empList.Find(e => e.EmployeeID == empID);
            if (emp == null)
                throw new Exception("Employee not found to delete");
            empList.Remove(emp);
        }

        public Employee[] FindEmployee(string name)
        {
            return empList.FindAll(e => e.EmployeeName.Contains(name)).ToArray();
        }

        public Employee FindEmployee(int id)
        {
            return empList.Find(e => e.EmployeeID == id);
        }

        public void UpdateEmployee(Employee emp)
        {
            var foundEmp = empList.Find(e => e.EmployeeID == emp.EmployeeID);
            if (emp == null)
                throw new Exception("Employee not found to update");
            foundEmp.EmployeeName = emp.EmployeeName;
            foundEmp.EmployeeAddress = emp.EmployeeAddress;
            foundEmp.EmployeeDateOfBirth = emp.EmployeeDateOfBirth;
        }
    }

    public static class ComponentFactory
    {
        public static IDataComponent CreateComponent()
        {
            return new ListDataComponent();
        }
    }
}
