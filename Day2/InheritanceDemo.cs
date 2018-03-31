using System;
using System.Diagnostics;//This namespace contains classes to perform tracing, debug handling and many more about the maintainance of UR Application..
using SampleConApp.Entities;
using System.Collections.Generic;//C# 2.0 Collections(Type safe collections)..
//using SampleConApp.DataLayer;//This is the old class that we created yesterday....

namespace SampleConApp.DataLayer
{
    interface IDataComponent
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
    //Inheritance in C# is single inheritance.
    class CollectionComponent : DataComponent
    {
        private List<Employee> _empList = new List<Employee>();
        //override keyword is used to tell the runtime that this function is modified by the Derived class and would invoke when the method is called...override keyword can be used on only those methods that are marked as virtual in their base classes..
        public override void AddNewEmployee(Employee emp)
        {
            Debug.WriteLine("Adding to List<Employee>");
            if (emp == null) throw new Exception("Employee details are not set");
            _empList.Add(emp);//Adds the new element to the bottom of the list....
            //base.AddNewEmployee(emp);
        }

        public override void DeleteEmployee(int id)
        {
            Debug.WriteLine("removing from List<Employee>");
            for (int i = 0; i < _empList.Count; i++)
            {
                if(_empList[i].EmployeeID == id)
                {
                    _empList.Remove(_empList[i]);
                    return;
                }
            }
            throw new Exception("No Employee found to delete by this Id");
        }

        public override Employee FindEmployee(string name)
        {
            Debug.WriteLine("Finding from the List<Employee>");
            foreach(var e in _empList)
            {
                if (e.EmployeeName== name)
                    return e;
            }
            throw new Exception("No employee found by that name");
           // return _empList.Find((e) => e.EmployeeName==name);
        }

        //This is extended.....
        public Employee[] FindAllEmployees(string name)
        {
            List<Employee> _tempList = new List<Employee>();//no elements now....
            foreach(var emp in _empList)
            {
                if (emp.EmployeeName.Contains(name))
                    _tempList.Add(emp);
            }
            return _tempList.ToArray();
        }
        public override void UpdateEmployee(Employee emp)
        {
            base.UpdateEmployee(emp);
        }
        //We wish to modify the functions of the base class.....
    }
}